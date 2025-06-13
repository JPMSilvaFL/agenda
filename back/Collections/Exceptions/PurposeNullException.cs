namespace AgendaApi.Collections.Exceptions;

public class PurposeNullException : Exception {
	public PurposeNullException() { }
	public PurposeNullException(string message) : base(message) { }

	public PurposeNullException(string message, Exception inner) : base(message,
		inner) { }
}