namespace AgendaApi.Collections.Enum;

public enum ELogCode {
	// Success
	CreatePerson = 1,
	CreateUser = 2,
	CreateAccess = 3,
	CreateCustomer = 4,
	CreatePurpose = 5,
	CreateRole = 6,
	CreateEmployee = 7,
	CreateSchedule = 8,
	CreateSecretary = 9,

	// Errors
	DuplicatePersonKeys = 1001,
	AvailableError = 1002,
	ErrorGettingPurpose = 1003
}