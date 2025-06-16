namespace AgendaApi.Collections.Exceptions;

public class ScheduledException : Exception {
	public ScheduledException() { }
	public ScheduledException(string message) : base(message) { }

	public ScheduledException(string message, Exception inner) : base(
		message, inner) { }
}