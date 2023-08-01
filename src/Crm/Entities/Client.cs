namespace Crm.Entities;



public sealed class Client
{
    private string? _userFirstName;
    private string? _userLastName;
    private string? _userMiddleName;
    public short userAge;
    private string? _userPassportNumber; 
    public required string FirstName 
    {
        get => _userFirstName ?? string.Empty;
        init => _userFirstName = value is {Length: > 2} ? value : throw new Exception("Поле First name не может содержать только один символ!");
    }
    public required string LastName
    {
        get => _userLastName ?? string.Empty;
        init => _userLastName = value is {Length: > 2} ? value : throw new Exception("Поле Last name не может содержать только один символ!");
    }
    public required string MiddleName
    {
        get => _userMiddleName ?? string.Empty;
        init => _userMiddleName = value is {Length: < 1} ? throw new Exception("Пустое поле middle name не допускается!") : value;
    }
    public short Age
    {
        get
        {
            return userAge;
        }
        init
        {
            if(userAge < 0)
                throw new Exception("Введенно нулевое значение возвроста");
            else userAge = value;
        }
    }
    public required string PassportNumber
    {
        get => _userPassportNumber ?? string.Empty;
        init => _userPassportNumber = value is {Length : < 4} ? throw new Exception("Номер пасспорта состоит минимум из 4 цифр!") : _userPassportNumber = value;
    }
    public Gender Gender { get; init; }
}
