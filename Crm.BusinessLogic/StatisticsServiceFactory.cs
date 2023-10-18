using Crm.DataAccess;
namespace Crm.BusinessLogic;

public static class StatisticsServiceFactory
{
    public static IStatisticsService CreateStatisticsService()
    {
        IClientRepository clientRepository = new ClientRepository();
        IOrderRepository orderRepository = new OrderRepository();
        IOrderRepository orderRepository1 = new PosgreSqlOrderRepository();
        return new StatisticsService(orderRepository1, clientRepository);
    }
}