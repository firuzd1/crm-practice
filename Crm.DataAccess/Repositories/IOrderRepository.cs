namespace Crm.DataAccess;

public interface IOrderRepository
{
    ValueTask<bool> CreateAsync(Order order, CancellationToken cancellationToken = default);
    public ValueTask<Order> GetOrderAsync(string myOrderDescription, CancellationToken cancellationToken = default);
    public ValueTask<bool> ChangeDescriptionAsync(string find, string newDescription, CancellationToken cancellationToken = default);
    ValueTask<bool> UpdateOrderStateAsync(long orderId, OrderState orderState, CancellationToken cancellationToken = default);
    ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default);
    ValueTask<int> GetOrderCountAsync(OrderState orderState, CancellationToken cancellationToken = default);
    ValueTask<bool> DeleteOrderAsync(string forDelete, CancellationToken cancellationToken = default);
}
