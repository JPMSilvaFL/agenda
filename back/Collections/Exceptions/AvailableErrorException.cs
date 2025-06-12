namespace AgendaApi.Collections.Exceptions;

public class AvailableErrorException : Exception {
	public AvailableErrorException() { }
	public AvailableErrorException(string message) : base(message) { }

	public AvailableErrorException(string message, Exception inner) : base(
		message, inner) { }
}