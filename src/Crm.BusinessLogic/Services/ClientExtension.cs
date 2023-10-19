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

    public static Client ToClient(this ClientInfo clientInfo)
    {
        Client client = new Client()
        {
            FirstName = clientInfo.FirstName,
            LastName = clientInfo.LastName,
            MiddleName = clientInfo.MiddleName,
            Age = clientInfo.Age,
            PassportNumber = clientInfo.PassportNumber,
            Gender = clientInfo.Gender.ToGenderEnum(),
            UserPhone = clientInfo.Phone,
            UserEmail = clientInfo.Email,
            UserPassword = clientInfo.Password
        };
        return client;
    }
}