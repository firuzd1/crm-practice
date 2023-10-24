using Crm.DataAccess;
namespace Crm.BusinessLogic;


public sealed class OrderService : IOrderService
{

    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderService()
    {
    }


    private long _id = 0;
    private readonly List<Order> _orderList = new List<Order>();
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
    public OrderInfo GetOrder(string myOrderDescription)
    {
        Order order = _orderRepository.GetOrder(myOrderDescription);
        OrderInfo orderInfo = order.ToOrderInfo();
        return orderInfo;
    }
    public bool ChangeDescription(string find, string newDescription)
    {
        return _orderRepository.ChangeDescription(find, newDescription);
    }
    public bool DeleteOrder(string forDelete)
    {
        return _orderRepository.DeleteOrder(forDelete);
    }

    public int GetOrderCount()
    {
        return _orderRepository.GetOrderCount();
    }

    public bool UpdateOrderState(int orderId, OrderState newOrderState)
    {
        return _orderRepository.UpdateOrderState(orderId, newOrderState);
    }

}