using Crm.DataAccess;
namespace Crm.BusinessLogic;


public sealed class PostgreClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ValueTask<bool> ChangeClientNameAsync(string name, string lastName, string newFirstName, string newLastname, CancellationToken cancellationToken = default) =>
    _clientRepository.ChangeClientNameAsync(name, lastName, newFirstName, newLastname, cancellationToken);

    public async ValueTask<bool> CreateClientAsync(ClientInfo clientInfo, CancellationToken cancellationToken = default) =>
        await _clientRepository.CreateClientAsync(clientInfo.ToClient(), cancellationToken);

    public async ValueTask<ClientInfo?> GetClientAsync(string firstName, string lastName, CancellationToken cancellationToken = default)
    {
        Client client = await _clientRepository.GetClientAsync(firstName, lastName, cancellationToken); 
        return client.ToClientInfo();
    }

    public async ValueTask<int> GetClientCountAsync(CancellationToken cancellationToken = default) =>
        await _clientRepository.GetClientCountAsync(cancellationToken);
}