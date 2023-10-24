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

    public async ValueTask<int> GetClientCountAsync(CancellationToken cancellationToken = default) => await _clientRepository.GetClientCountAsync(cancellationToken);
    public ValueTask<bool> CreateClientAsync(ClientInfo clientInfo, CancellationToken cancellationToken = default)
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

        return _clientRepository.CreateClientAsync(newClient, cancellationToken);
    }

    public async ValueTask<ClientInfo?> GetClientAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        Client client = await _clientRepository.GetClientAsync(firstName, lastName, cancellationToken);
        ClientInfo clientInfo = client.ToClientInfo();
        return clientInfo;
    }
    public async ValueTask<bool> ChangeClientNameAsync(string name, string lastName, string newFirstName, string newLastname, CancellationToken cancellationToken)
    {
        return await _clientRepository.ChangeClientNameAsync(name, lastName, newFirstName, newLastname, cancellationToken);
    }

}

