using System;
using System.Diagnostics.Contracts;
using Crm.Entities;
namespace Crm.Services;

public sealed class ClientService
{
    private List<Client> _clientList = new List<Client>();
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
        _clientList.Add(newClient);

        return newClient;
    }

    public Client? GetClient(string firstName, string lastName)
    {
        if (firstName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(firstName));
        if (lastName is not { Length: > 0 })
            throw new ArgumentNullException(nameof(lastName));
        System.Console.WriteLine("Before foreach " + _clientList.FirstOrDefault().FirstName);
        foreach (Client client in _clientList)
        {
            System.Console.WriteLine("Get Client "+client.FirstName);
            if (client.FirstName.Equals(firstName) && client.LastName.Equals(lastName))
            {
                return client;
            }
        }
        return null;
    }

 

}