using Crm.DataAccess;
namespace Crm.BusinessLogic;


public sealed class PostgreClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public bool ChangeClientName(string name, string lastName, string newFirstName, string newLastname) =>
    _clientRepository.ChangeClientName(name, lastName, newFirstName, newLastname);

    public bool CreateClient(ClientInfo clientInfo) =>
        _clientRepository.CreateClient(clientInfo.ToClient());

    public ClientInfo? GetClient(string firstName, string lastName) =>
        (_clientRepository.GetClient(firstName, lastName)).ToClientInfo();

    public int GetClientCount() =>
        _clientRepository.GetClientCount();
}