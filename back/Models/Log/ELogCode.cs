namespace AgendaApi.Models.Log;

public enum ELogCode {
	// Success
	CreatePerson = 1,
	CreateUser = 2,

	// Errors
	DuplicatePersonKeys = 1001
}