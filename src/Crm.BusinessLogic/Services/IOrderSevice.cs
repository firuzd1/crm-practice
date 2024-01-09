using Crm.DataAccess;
namespace Crm.BusinessLogic;


public interface IOrderService
{
    public ValueTask<bool> CreateOrderAsync(OrderInfo orderInfo, CancellationToken cancellationToken = default);
    public ValueTask<OrderInfo> GetOrderAsync(string myOrderDescription, CancellationToken cancellationToken = default);
    public ValueTask<bool> ChangeDescriptionAsync(string find, string newDescription, CancellationToken cancellationToken = default);
    public ValueTask<bool> DeleteOrderAsync(string forDelete, CancellationToken cancellationToken = default);
    public ValueTask<bool> UpdateOrderStateAsync(int orderId, OrderState newOrderState, CancellationToken cancellationToken = default);
    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default);

}