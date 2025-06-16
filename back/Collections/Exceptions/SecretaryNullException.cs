namespace AgendaApi.Collections.Exceptions;

public class SecretaryNullException : Exception {
	public SecretaryNullException() { }
	public SecretaryNullException(string message) : base(message) { }

	public SecretaryNullException(string message, Exception inner) : base(message,
		inner) { }
}