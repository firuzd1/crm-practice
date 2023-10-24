namespace Crm.BusinessLogic;
using Crm.DataAccess;

public interface IClientService
{
    public int GetClientCount();
    public bool CreateClient(ClientInfo clientInfo);
    public ClientInfo? GetClient(string firstName, string lastName);
    public bool ChangeClientName(string name, string lastName, string newFirstName, string newLastname);
}
