using Crm.DataAccess;
namespace Crm.BusinessLogic;


public interface IOrderService
{
    public bool CreateOrder(OrderInfo orderInfo);
    public OrderInfo? GetOrder(string myOrderDescription);
    public bool ChangeDescription(string find, string newDescription);
    public bool DeleteOrder(string forDelete); 
    public bool UpdateOrderState(long orderId, OrderState newOrderState)
    {
        throw new NotImplementedException();
    }
    public int GetOrderCount();

}