using System.Text;
using System.Text.Json.Serialization;
using AgendaApi;
using AgendaApi.Collections.Repositories;
using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Repositories.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Collections.Services.Profiles;
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
app.MapControllers();
app.UseHttpsRedirection();
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

	builder.Services.AddCors(options =>
	{
		options.AddPolicy("MyCorsPolicy", // Nome da política
			policy =>
			{
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


	builder.Services.AddTransient<UserService>();
	builder.Services.AddTransient<IPersonService, PersonService>();
	builder.Services.AddTransient<ICustomerService, CustomerService>();
	builder.Services.AddTransient<IUserService, UserService>();
	builder.Services.AddTransient<IAccessService, AccessService>();
	builder.Services.AddTransient<ITokenService, TokenService>();
	builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();


	builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
	builder.Services.AddTransient<IUserRepository, UserRepository>();
	builder.Services.AddTransient<IPersonRepository, PersonRepository>();
	builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
	builder.Services.AddTransient<IAccessRepository, AccessRepository>();
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