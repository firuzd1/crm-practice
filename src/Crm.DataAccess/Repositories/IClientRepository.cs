namespace Crm.DataAccess;


public interface IClientRepository
{
    public int GetClientCount();
    public bool CreateClient(Client client);
    public Client GetClient(string firstName, string lastName);
    public bool ChangeClientName(string name, string lastName, string newFirstName, string newLastname);

}
