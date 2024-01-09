using Crm.DataAccess;
namespace Crm.BusinessLogic;


public sealed class PostgreOrderService : IOrderService
{
    private long _id = 0;
    private readonly IOrderRepository _orderRepository;
    public async ValueTask<bool> ChangeDescriptionAsync(string find, string newDescription, CancellationToken cancellationToken = default)
     => await _orderRepository.ChangeDescriptionAsync(find, newDescription, cancellationToken);
    
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

    public async ValueTask<bool> DeleteOrderAsync(string forDelete, CancellationToken cancellationToken = default) 
        => await _orderRepository.DeleteOrderAsync(forDelete, cancellationToken);

    public async ValueTask<OrderInfo> GetOrderAsync(string myOrderDescription, CancellationToken cancellationToken = default)
    {
        Order order = await _orderRepository.GetOrderAsync(myOrderDescription, cancellationToken);
        OrderInfo orderInfo = order.ToOrderInfo();
        return orderInfo;
    }

    public async ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default) 
        => await _orderRepository.GetOrderCountAsync(cancellationToken);
        
    public ValueTask<bool> UpdateOrderStateAsync(int orderId, OrderState newOrderState, CancellationToken cancellationToken = default) 
        => _orderRepository.UpdateOrderStateAsync(orderId, newOrderState, cancellationToken);
}
