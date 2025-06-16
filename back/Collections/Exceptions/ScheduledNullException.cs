namespace AgendaApi.Collections.Exceptions;

public class ScheduledNullException : Exception {
	public ScheduledNullException() { }
	public ScheduledNullException(string message) : base(message) { }

	public ScheduledNullException(string message, Exception inner) : base(message,
		inner) { }
}