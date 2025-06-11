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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();


LoadConfiguration(app);

app.UseCors("MyCorsPolicy");
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.Run();

void ConfigureMvc(WebApplicationBuilder builder) {
	builder
		.Services
		.AddControllers()
		.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
		.AddJsonOptions(x => {
			x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
		});
}

void ConfigureServices(WebApplicationBuilder builder) {
	builder.Services.AddCors(options => {
		options.AddPolicy("MyCorsPolicy", // Nome da política
			policy => {
				policy.WithOrigins("http://localhost:5173"); // Origens permitidas
				policy.WithMethods("GET", "POST", "PUT", "DELETE"); // Métodos HTTP permitidos
				policy.WithHeaders("Content-Type", "Authorization"); // Headers permitidos
				// policy.AllowAnyOrigin(); // Permite todas as origens (não recomendado para produção)
				// policy.AllowAnyMethod(); // Permite todos os métodos (não recomendado para produção)
				// policy.AllowAnyHeader(); // Permite todos os headers (não recomendado para produção)
				policy.AllowCredentials(); // Permite credenciais (cookies, autenticação)
			});
	});

	builder.Services.AddDbContext<AgendaDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
	builder.Services.AddScoped<ILogActivityService, LogActivityService>();


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