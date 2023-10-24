namespace Crm.DataAccess;

public interface IOrderRepository
{
    bool Create(Order order);
    public Order GetOrder(string myOrderDescription);
    public bool ChangeDescription(string find, string newDescription);
    bool UpdateOrderState(long orderId, OrderState orderState);
    int GetOrderCount();
    int GetOrderCount(OrderState orderState);
    bool DeleteOrder(string forDelete);
}
