using Crm.Entities;

namespace Crm.Services;

public sealed class ClientService
{
    private List<Client> clientList = new List<Client>();
    public Client CreateClient(ClientInfo clientInfo)
    {
        Client newClient = new Client()
        {
            FirstName = clientInfo.FirstName,
            LastName = clientInfo.LastName,
            MiddleName = clientInfo.MiddleName,
            Age = clientInfo.Age,
            PassportNumber = clientInfo.PassportNumber,
            Gender = clientInfo.Gender,
            UserPhone = clientInfo.UserPhone,
            UserEmail = clientInfo.UserEmail,
            UserPassword = clientInfo.UserPassword
        };
        clientList.Add(newClient);
        return newClient;
    }
    
}