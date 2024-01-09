using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Crm.DataAccess;

[Table("client")]
public sealed class Client
{
    private string? _userFirstName;
    private string? _userLastName;
    private string? _userMiddleName;
    private short _userAge;
    private string? _userPassportNumber; 
    private string? _userPhone;
    private string? _userEmail;
    private string? _userPassword;

    public long Id { get; set; }

    public required string FirstName 
    {
        get => _userFirstName ?? string.Empty;
        set => _userFirstName = value is {Length: > 2} ? value : throw new Exception("Поле First name не может содержать только один символ!");
    }

    public required string LastName
    {
        get => _userLastName ?? string.Empty;
        set => _userLastName = value is {Length: > 2} ? value : throw new Exception("Поле Last name не может содержать только один символ!");
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
            return _userAge;
        }
        init
        {
            if(_userAge < 0)
                throw new Exception("Введенно нулевое значение возвроста");
            else _userAge = value;
        }
    }

    public required string PassportNumber
    {
        get => _userPassportNumber ?? string.Empty;
        init => _userPassportNumber = value is {Length : < 4} ? throw new Exception("Номер пасспорта состоит минимум из 4 цифр!") : _userPassportNumber = value;
    }

    public Gender Gender { get; init; }

    public required string UserPhone
    {
        get => _userPhone ?? string.Empty;
        init => _userPhone = value is {Length: > 1} ? value : throw new Exception("Поле Phone не может быть пустым!");
    }

    public required string UserEmail
    {
        get => _userEmail ?? string.Empty;
        init => _userEmail = value is {Length: > 1} ? value : throw new Exception("Поле e-mail не может быть пустой!");
    }

    public required string UserPassword
    {
        get => _userPassword ?? string.Empty;
        init => _userPassword = value is {Length: > 1} ? value : throw new Exception("Поле пароль не может быть пустой!");
    }

    public ICollection<Order> Orders { get; set; }
}
