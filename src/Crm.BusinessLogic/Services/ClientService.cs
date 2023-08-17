using System;
using System.Diagnostics.Contracts;
using Crm.DataAccess;
namespace Crm.BusinessLogic;

public sealed class ClientService : IClientService
{
    private readonly List<Client> _clientList;

    public ClientService()
    {
        _clientList = new();
    }
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
        foreach (Client client in _clientList)
        {
            if (client.FirstName == firstName && client.LastName == lastName)
            {
                return client;
            }
        }
        return null;
    }

    public Client? ChangeClientName(string name, string lastName, string newFirstName, string newLastname)
    {
        if(name is not {Length: > 0})
            throw new ArgumentNullException(nameof(name));
        if(lastName is not {Length: > 0})
            throw new ArgumentNullException(nameof(lastName));
        foreach(Client client in _clientList)
        {
            if(client.FirstName.Equals(name) && client.LastName.Equals(lastName))
            {
                client.FirstName = newFirstName;
                client.LastName = newLastname;
                return client;
            }
            else throw new Exception("Пользователь не найден!");
        }
        return null;
    }
    public int userStat()
    {
        int count = 0;
        foreach(Client registratedClients in _clientList)
        {
            count++;
        }
        return count;
    }

}