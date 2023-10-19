namespace Crm.BusinessLogic;

public readonly record struct ClientInfo(
    long Id,
    string FirstName,
    string LastName,
    string MiddleName,
    string Phone,
    string Email,
    string PassportNumber,
    short Age,
    string Gender,
    string Password);