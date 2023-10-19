/*
namespace Crm.DataAccess;

public class ClientRepository : IClientRepository
{
    private readonly List<Client> _clients;

    public ClientRepository()
    {
        _clients = new List<Client>();
    }
    public int GetClientCount() => _clients.Count;
    public bool CreateClient(Client client)
    {
        if (client is not null)
        {
            _clients.Add(client);
            return true;
        }
        return false;
    }
    public Client GetClient(string firstName, string lastName)
    {
        if (firstName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(firstName));
        if (lastName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(lastName));
        Client? client = _clients.Find(c => c.FirstName.Equals(firstName) && c.LastName.Equals(lastName));
        ClientInfo2 clientInfo = new();
        return client is null ? throw new NotFoundException() : client;
    }
    public bool ChangeClientName(string name, string lastName, string newFirstName, string newLastname)
    {
        if (name is not { Length: > 0 })
            throw new ArgumentNullException(nameof(name));
        if (lastName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(lastName));
        Client? client = _clients.Find(c => c.FirstName.Equals(name) && c.LastName.Equals(lastName)) ?? throw new NotFoundException();
        client.FirstName = newFirstName;
        client.LastName = newLastname;
        return true;
    }


}
*/