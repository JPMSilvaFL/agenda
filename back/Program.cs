using System.Text;
using System.Text.Json.Serialization;
using AgendaApi;
using AgendaApi.Collections.Middlewares;
using AgendaApi.Collections.Repositories;
using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Repositories.Interfaces.Schedule;
using AgendaApi.Collections.Repositories.Interfaces.Utilities;
using AgendaApi.Collections.Repositories.Profiles;
using AgendaApi.Collections.Repositories.Schedule;
using AgendaApi.Collections.Repositories.Utilities;
using AgendaApi.Collections.Services.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces.Schedule;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.Services.Profiles;
using AgendaApi.Collections.Services.Schedule;
using AgendaApi.Collections.Services.Utilities;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();

LoadConfiguration(app);

app.UseCors("MyCorsPolicy");
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
CreateSuperUser(app);
app.Run();

void ConfigureMvc(WebApplicationBuilder builder) {
	builder
		.Services
		.AddControllers()
		.ConfigureApiBehaviorOptions(options => {
			options.SuppressModelStateInvalidFilter = true;
		})
		.AddJsonOptions(x => {
			x.JsonSerializerOptions.ReferenceHandler =
				ReferenceHandler.IgnoreCycles;
			x.JsonSerializerOptions.DefaultIgnoreCondition =
				JsonIgnoreCondition.WhenWritingDefault;
		});
}

void ConfigureServices(WebApplicationBuilder builder) {
	builder.Services.AddCors(options => {
		options.AddPolicy("MyCorsPolicy", // Nome da política
			policy => {
				policy.WithOrigins(
					"http://localhost:5173"); // Origens permitidas
				policy.WithMethods("GET", "POST", "PUT",
					"DELETE"); // Métodos HTTP permitidos
				policy.WithHeaders("Content-Type",
					"Authorization"); // Headers permitidos
				// policy.AllowAnyOrigin(); // Permite todas as origens (não recomendado para produção)
				// policy.AllowAnyMethod(); // Permite todos os métodos (não recomendado para produção)
				// policy.AllowAnyHeader(); // Permite todos os headers (não recomendado para produção)
				policy
					.AllowCredentials(); // Permite credenciais (cookies, autenticação)
			});
	});
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	builder.Services.AddDbContext<AgendaDbContext>(options =>
		options.UseSqlServer(
			builder.Configuration.GetConnectionString("DefaultConnection")));

	builder.Services.AddHttpContextAccessor();
	// builder.Services.AddScoped<ExceptionMiddleware>();

	builder.Services.AddScoped<UserService>();
	builder.Services.AddScoped<IPersonService, PersonService>();
	builder.Services.AddScoped<ICustomerService, CustomerService>();
	builder.Services.AddScoped<IUserService, UserService>();
	builder.Services.AddScoped<IAccessService, AccessService>();
	builder.Services.AddScoped<ITokenService, TokenService>();
	builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();
	builder.Services.AddScoped<IAvailableService, AvailableService>();
	builder.Services.AddScoped<IPurposeService, PurposeService>();
	builder.Services.AddTransient<ILogActivityService, LogActivityService>();
	builder.Services.AddScoped<IRoleService, RoleService>();
	builder.Services.AddScoped<IEmployeeService, EmployeeService>();
	builder.Services.AddScoped<IScheduledService, ScheduledService>();
	builder.Services.AddScoped<ISecretaryService, SecretaryService>();
	builder.Services.AddScoped<IVerificationService, VerificationService>();


	builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
	builder.Services.AddScoped<IAvailableRepository, AvailableRepository>();
	builder.Services.AddScoped<IUserRepository, UserRepository>();
	builder.Services.AddScoped<IPersonRepository, PersonRepository>();
	builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
	builder.Services.AddScoped<IAccessRepository, AccessRepository>();
	builder.Services.AddScoped<ISecretaryRepository, SecretaryRepository>();
	builder.Services.AddScoped<IPurposeRepository, PurposeRepository>();
	builder.Services.AddScoped<IScheduledRepository, ScheduledRepository>();
	builder.Services.AddScoped<ILogActivityRepository, LogActivityRepository>();
	builder.Services.AddScoped<IRoleRepository, RoleRepository>();
	builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
}

void ConfigureAuthentication(WebApplicationBuilder builder) {
	var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
	builder.Services.AddAuthentication(x => {
		x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	}).AddJwtBearer(x => {
		x.TokenValidationParameters = new TokenValidationParameters {
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
}

void LoadConfiguration(WebApplication app) {
	Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey")!;
}

void CreateSuperUser(WebApplication app) {
	using var scope = app.Services.CreateScope();
	var context = scope.ServiceProvider.GetRequiredService<AgendaDbContext>();
	var passwordHasher = new PasswordHasher<User>();
	if (!context
		    .Users
		    .Include(x=>x.FromAccess)
		    .Any(x=>x.FromAccess!.Name == "Admin")) {
		var access = new Access {
			Id = Guid.Parse("8d22b8b3-4c12-40fa-9b7a-73f6ce2a08a9"),
			Name = "Admin",
		};
		var person = new Person {
			Id= Guid.Parse("3db61c58-7f07-45a5-9aaf-70a73ac2e63a"),
			FullName= "Sistema",
			Email= "Sistema@sistema.com",
			Phone= "64993140912",
			Document = "01234567891",
			Type= "J",
			Address= "Rua 7, 103c"
		};
		var admin = new User {
			Id = Guid.Parse("76207e5b-3fc5-4ad6-a7c0-c7bb7d1cfcae"),
			IdAccess = access.Id,
			IdPerson = person.Id,
			Username = "Sistema.admin",
			PasswordHash = "152369Sistema@"
		};
		admin.PasswordHash = passwordHasher.HashPassword(admin, admin.PasswordHash);
		context.Accesses.Add(access);
		context.Persons.Add(person);
		context.Users.Add(admin);
		context.SaveChanges();

		Console.WriteLine("✅ Admin criado com sucesso!");
	}
	else
	{
		Console.WriteLine("ℹ️ Admin já existe.");
	}
}
