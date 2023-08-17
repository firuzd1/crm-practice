namespace Crm.BusinessLogic;
using Crm.DataAccess;

interface IClientService
{
    public Client CreateClient(ClientInfo clientInfo);
    public Client? GetClient(string firstName, string lastName);
    public Client? ChangeClientName(string name, string lastName, string newFirstName, string newLastname);
    public int userStat();
}
