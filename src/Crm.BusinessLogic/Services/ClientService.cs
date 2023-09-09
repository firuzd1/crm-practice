using Crm.DataAccess;
namespace Crm.BusinessLogic;

public static class GenderExtention
{
     public static Gender ToGenderEnum(this string genderStr)
        => Enum.Parse<Gender>(genderStr);
     

}

public sealed class ClientService : IClientService
{
    private readonly List<Client> _clientList;
    private long _id = 0;

    public ClientService()
    {
        _clientList = new();
    }
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public int GetClientCount() => _clientRepository.GetClientCount();
    public bool CreateClient(ClientInfo clientInfo)
    {
        Client newClient = new Client()
        {
            Id = _id++,
            FirstName = clientInfo.FirstName,
            LastName = clientInfo.LastName,
            MiddleName = clientInfo.MiddleName,
            Age = clientInfo.Age,
            PassportNumber = clientInfo.PassportNumber,
            Gender = clientInfo.Gender.ToGenderEnum(),
            UserPhone = clientInfo.Phone,
            UserEmail = clientInfo.Email,
            UserPassword = clientInfo.Password
        };

        return _clientRepository.CreateClient(newClient);
    }

    public ClientInfo? GetClient(string firstName, string lastName)
    {
       Client client = _clientRepository.GetClient(firstName, lastName);
       ClientInfo clientInfo = client.ToClientInfo();
       return clientInfo;
    }
    public bool ChangeClientName(string name, string lastName, string newFirstName, string newLastname)
    {
        return _clientRepository.ChangeClientName(name, lastName,newFirstName, newLastname);
    }

}

