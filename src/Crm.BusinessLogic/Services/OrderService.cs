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
    public async ValueTask<bool> CreateOrderAsync(OrderInfo orderInfo, CancellationToken cancellationToken = default)
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
        return await _orderRepository.CreateAsync(newOrder, cancellationToken);
    }
    public async ValueTask<OrderInfo> GetOrderAsync(string myOrderDescription, CancellationToken cancellationToken = default)
    {
        Order order = await _orderRepository.GetOrderAsync(myOrderDescription, cancellationToken);
        OrderInfo orderInfo = order.ToOrderInfo();
        return orderInfo;
    }
    public async ValueTask<bool> ChangeDescriptionAsync(string find, string newDescription, CancellationToken cancellationToken = default)
    {
        return await _orderRepository.ChangeDescriptionAsync(find, newDescription, cancellationToken);
    }
    public ValueTask<bool> DeleteOrderAsync(string forDelete, CancellationToken cancellationToken = default)
    {
        return _orderRepository.DeleteOrderAsync(forDelete, cancellationToken);
    }

    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default)
    {
        return _orderRepository.GetOrderCountAsync(cancellationToken);
    }

    public ValueTask<bool> UpdateOrderStateAsync(int orderId, OrderState newOrderState, CancellationToken cancellationToken = default)
    {
        return _orderRepository.UpdateOrderStateAsync(orderId, newOrderState, cancellationToken);
    }

}