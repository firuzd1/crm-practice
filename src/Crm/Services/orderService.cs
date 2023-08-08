using Crm.Entities;
namespace Crm.Services;

public sealed class OrderService
{
    private readonly List<Order> _orderList = new List<Order>();
    public Order CreateOrder(OrderInfo orderInfo)
    {
        Order newOrder = new Order()
        {
            OrderId = orderInfo.OrderId,
            OrderDescription = orderInfo.OrderDescription,
            OrderPrice = orderInfo.OrderPrice,
            OrderDate = orderInfo.OrderDate,
            OrderDeliveryType = orderInfo.OrderDeliveryType,
            OrderDeliveryAddress = orderInfo.OrderDeliveryAddress
        };
        _orderList.Add(newOrder);
        return newOrder;
    }
    public Order GetOrder(string myOrderDescription)
    {
        if (myOrderDescription is not { Length: > 0 })
            throw new ArgumentNullException(nameof(myOrderDescription));
 
        foreach (Order myOrder in _orderList)
        {
            if (myOrder.orderDescription.Equals(myOrderDescription))
            {
                return myOrder;
            }
        }
        return null;
    }
}