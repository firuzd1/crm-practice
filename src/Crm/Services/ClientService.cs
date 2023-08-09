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
        foreach (Client client in _clientList)
        {
            if (client.FirstName == firstName && client.LastName == lastName)
            {
                return client;
            }
        }
        return null;
    }

    public Client? ChangeClientName(string name, string lastName)
    {
        if(name is not {Length: > 0})
            throw new ArgumentNullException(nameof(name));
        if(lastName is not {Length: > 0})
            throw new ArgumentNullException(nameof(lastName));
        foreach(Client client in _clientList)
        {
            if(client.FirstName.Equals(name) && client.LastName.Equals(lastName))
            {
                System.Console.WriteLine("Измените имя: ");
                client.FirstName = Console.ReadLine();
                System.Console.WriteLine("Измените фамилию: ");
                client.LastName = Console.ReadLine();
                return client;
            }
            else throw new Exception("Пользователь не найден!");
        }
        return null;
    }

}