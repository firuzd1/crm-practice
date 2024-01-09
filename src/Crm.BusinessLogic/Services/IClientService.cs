namespace Crm.BusinessLogic;
using Crm.DataAccess;

public interface IClientService
{
    public ValueTask<int> GetClientCountAsync(CancellationToken cancellationToken = default);
    public ValueTask<bool> CreateClientAsync(ClientInfo clientInfo, CancellationToken cancellationToken = default);
    public ValueTask<ClientInfo?> GetClientAsync(string firstName, string lastName, CancellationToken cancellationToken = default);
    public ValueTask<bool> ChangeClientNameAsync(string name, string lastName, string newFirstName, string newLastname, CancellationToken cancellationToken);
}
