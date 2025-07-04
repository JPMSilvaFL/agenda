﻿namespace AgendaApi.Collections.Exceptions;

public class UserNullException : Exception {
	public UserNullException() { }
	public UserNullException(string message) : base(message) { }

	public UserNullException(string message, Exception inner) : base(
		message, inner) { }
}