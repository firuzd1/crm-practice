using Crm.DataAccess;

namespace Crm.BusinessLogic;
public static class ClientExtension
{
    public static ClientInfo ToClientInfo(this Client client)
    {
        ClientInfo clientInfo = new(
            client.Id,
            client.FirstName,
            client.LastName,
            client.MiddleName,
            client.UserPhone,
            client.UserEmail,
            client.PassportNumber,
            client.Age,
            client.Gender.ToString(),
            client.UserPassword);
        return clientInfo;
    }
}