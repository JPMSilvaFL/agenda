using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using AgendaApi.Models.Log;
using Microsoft.Data.SqlClient;

namespace AgendaApi.Collections.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;
	private readonly IServiceProvider _services;

	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceProvider services) {
		_services = services;
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context) {
		try {
			await _next(context);
		}
		catch (SqlException e) {
			_logger.LogError("DbError.");
			context.Response.StatusCode = 503;
			await context.Response.WriteAsync("An error occurred while attempting connection to database.");
		}
		catch (DuplicatePersonException e) {
			_logger.LogError("Creation Person failed.");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.DuplicatePersonKeys, e.Message);
			await context.Response.WriteAsync("Creation Person failed, because of duplicate keys in person");
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Unhandled exception.");
			context.Response.StatusCode = 500;
			await context.Response.WriteAsync("Unexpected error occurred.");
		}
	}
	private async Task CreateLogError(EAction action, ELogCode code, string message) {
		using (var scope = _services.CreateScope()) {
			var logService = scope.ServiceProvider.GetRequiredService<ILogActivityService>();
			await logService.CreateLog(ELogType.Error, action, code, Guid.Empty, $"{message}");
		}
	}
}
