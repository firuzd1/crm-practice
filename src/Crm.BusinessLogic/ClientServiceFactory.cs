using Crm.DataAccess;
namespace Crm.BusinessLogic;

public static class ClientServiceFactory
{ /*
    public static IClientService CreateClientService()
    {
       
        IClientRepository clientRepository = new ClientRepository();
        return new ClientService(clientRepository);
    }
*/
    public static IClientService CreatePostgreClientService()
    {
        IClientRepository postgreClientRepository = new PostgreSqlClientRepository();
        return new ClientService(postgreClientRepository);
    }
}