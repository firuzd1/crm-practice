using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Crm.DataAccess;

public class EfcoreClientRepository : IClientRepository
{
    private readonly CrmDbContex _db;
    public EfcoreClientRepository(CrmDbContex crmDbContex)
    {
        _db = crmDbContex;
    }
   
    public async ValueTask<bool> ChangeClientNameAsync(string name, string lastName, string newFirstName, string newLastname, CancellationToken cancellationToken = default)
    {
        try
        {
            Client client = await _db.client.AsNoTracking().FirstOrDefaultAsync(c => c.FirstName == name && c.LastName == lastName, cancellationToken);
            client.FirstName = newFirstName;
            client.LastName = newLastname;
            return await _db.SaveChangesAsync(cancellationToken) > 1;
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Ошибка при изменении имени клиента: " + ex.Message);
            return false;
        }
    }

    public async ValueTask<bool> CreateClientAsync(Client client, CancellationToken cancellationToken = default)
    {
        try
        {
            _db.client.AddAsync(client, cancellationToken);
            return await _db.SaveChangesAsync(cancellationToken) > 1;
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Ошибка при создании клиента: " + ex.Message);
            return false;
        }
    }

    public async ValueTask<Client> GetClientAsync(string firstName, string lastName, CancellationToken cancellationToken = default)
    {
        Client client = await _db.client.AsNoTracking().FirstOrDefaultAsync(c => c.FirstName == firstName && c.LastName == lastName, cancellationToken);
        return client;
    }

    public ValueTask<int> GetClientCountAsync(CancellationToken cancellationToken = default)
    {
        return new(_db.client.CountAsync(cancellationToken));
    }
}