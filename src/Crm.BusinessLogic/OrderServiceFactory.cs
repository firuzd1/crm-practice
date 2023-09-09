using Crm.DataAccess;
namespace Crm.BusinessLogic;

public static class OrderServiceFactory
{
    public static IOrderService CreateOrderService()
    {
        IOrderRepository orderRepository = new OrderRepository();
        return new OrderService(orderRepository);
    }
}