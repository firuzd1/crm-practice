using Crm.DataAccess;
namespace Crm.BusinessLogic;


public sealed class PostgreOrderService : IOrderService
{
    private long _id = 0;
    private readonly IOrderRepository _orderRepository;
    public bool ChangeDescription(string find, string newDescription)
    {
        throw new NotImplementedException();
    }

    public bool CreateOrder(OrderInfo orderInfo)
    {
        Order newOrder = new Order()
        {
            Id = _id++,
            Description = orderInfo.Description,
            Price = orderInfo.Price,
            Date = orderInfo.Date,
            DeliveryType = orderInfo.DeliveryType.ToDeliveryEnum(),
            DeliveryAddress = orderInfo.DeliveryAddress,
            MyOrderState = orderInfo.NewOrderState.ToOrderEnum()
        };
        return _orderRepository.Create(newOrder);
    }

    public bool DeleteOrder(string forDelete)
    {
        throw new NotImplementedException();
    }

    public OrderInfo? GetOrder(string myOrderDescription)
    {
        throw new NotImplementedException();
    }

    public int GetOrderCount()
    {
        throw new NotImplementedException();
    }
    public bool UpdateOrderState(int orderId, OrderState newOrderState) => _orderRepository.UpdateOrderState(orderId, newOrderState);
}
