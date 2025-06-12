namespace AgendaApi.Models.Log;

public enum ELogCode {
	// Success
	CreatePerson = 1,
	CreateUser = 2,
	CreateAccess = 3,
	CreateCustomer = 4,
	CreatePurpose = 5,
	CreateRole = 6,
	CreateEmployee = 7,

	// Errors
	DuplicatePersonKeys = 1001,
	AvailableError = 1002
}