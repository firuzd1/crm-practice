namespace Crm.DataAccess;


public interface IClientRepository
{
    public ValueTask<int> GetClientCountAsync(CancellationToken cancellationToken = default);
    public ValueTask<bool> CreateClientAsync(Client client, CancellationToken cancellationToken = default);
    public ValueTask<Client> GetClientAsync(string firstName, string lastName, CancellationToken cancellationToken = default);
    public ValueTask<bool> ChangeClientNameAsync(string name, string lastName, string newFirstName, string newLastname, CancellationToken cancellationToken = default);

}
