namespace AgendaApi.Collections.Exceptions;

public class UserDuplicateKeyException : Exception {
	public UserDuplicateKeyException() { }
	public UserDuplicateKeyException(string message) : base(message) { }

	public UserDuplicateKeyException(string message, Exception inner) : base(
		message, inner) { }
}