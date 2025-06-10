namespace AgendaApi.Collections.Exceptions;

public class DuplicatePersonException : Exception{
	public DuplicatePersonException() { }
	public DuplicatePersonException(string message) : base(message) { }
	public DuplicatePersonException(string message, Exception inner) : base(message, inner) { }
}