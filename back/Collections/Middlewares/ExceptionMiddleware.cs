using AgendaApi.Collections.Enum;
using AgendaApi.Collections.Exceptions;
using AgendaApi.Collections.Services.Interfaces.Utilities;
using Microsoft.Data.SqlClient;

namespace AgendaApi.Collections.Middlewares;

public class ExceptionMiddleware {
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;
	private readonly IServiceProvider _services;

	public ExceptionMiddleware(RequestDelegate next,
		ILogger<ExceptionMiddleware> logger,
		IServiceProvider services) {
		_services = services;
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context) {
		try {
			await _next(context);
		}
		catch (SqlException) {
			_logger.LogError("DbError.");
			context.Response.StatusCode = 503;
			await context.Response.WriteAsync(
				"An error occurred while attempting connection to database.");
		}
		catch (UserDuplicateKeyException) {
			_logger.LogError("UserDuplicateKeyException");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Get, ELogCode.ErrorGettingPurpose,
				"Error registering user.");
			await context.Response.WriteAsync(
				"Username already exists! Try another username, please.");
		}
		catch (UserNullException e) {
			_logger.LogError("UserNullException");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.InvalidUserError,
				e.Message);
			await context.Response.WriteAsync(
				"User is returning null, verify and try again please.");
		}
		catch (PurposeNullException e) {
			_logger.LogError("Get purpose failed.");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Get, ELogCode.ErrorGettingPurpose,
				e.Message);
			await context.Response.WriteAsync(
				"Get purpose failed, please try again. If the error persist contact the system admin.");
		}
		catch (InvalidUserException e) {
			_logger.LogError("InvalidUserException");
			context.Response.StatusCode = 403;
			await CreateLogError(EAction.Created, ELogCode.InvalidUserError,
				e.Message);
			await context.Response.WriteAsync(
				"Invalid user, please try again. If the error persist contact the system admin.");
		}
		catch (ScheduledException e) {
			_logger.LogError("ScheduledException");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.ScheduledError,
				e.Message);
			await context.Response.WriteAsync(
				"Scheduled error, please try again.");
		}
		catch (ScheduledNullException e) {
			_logger.LogError("ScheduledNullException.");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.ScheduledNullError,
				e.Message);
			await context.Response.WriteAsync(
				"Scheduled is returning null, verify and try again please.");
		}
		catch (SecretaryNullException e) {
			_logger.LogError("SecretaryNullException.");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.SecretaryNullError,
				e.Message);
			await context.Response.WriteAsync(
				"Secretary is returning null, verify and try again please.");
		}
		catch (AvailableErrorException e) {
			_logger.LogError("Create Available failed.");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.AvailableError,
				e.Message);
			await context.Response.WriteAsync(
				"Create Available failed, please try again. If the error persist contact the system admin.");
		}
		catch (DuplicatePersonException e) {
			_logger.LogError("Create Person failed.");
			context.Response.StatusCode = 409;
			await CreateLogError(EAction.Created, ELogCode.DuplicatePersonKeys,
				e.Message);
			await context.Response.WriteAsync(
				"Creation Person failed, because of duplicate keys in person");
		}
		catch (Exception ex) {
			_logger.LogError(ex, "Unhandled exception.");
			context.Response.StatusCode = 500;
			await context.Response.WriteAsync("Unexpected error occurred.");
		}
	}

	private async Task CreateLogError(EAction action, ELogCode code,
		string message) {
		using var scope = _services.CreateScope();
		var logService = scope.ServiceProvider
			.GetRequiredService<ILogActivityService>();
		await logService.CreateLog(ELogType.Error, action, code, Guid.Empty,
			$"{message}");
	}
}