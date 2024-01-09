using Crm.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Crm.DataAccess;

[ApiController]
[Route("orders")]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost]
    public ValueTask<bool> CreateOrderAsync([FromBody] OrderInfo orderInfo, CancellationToken cancellationToken = default) 
        => _orderService.CreateOrderAsync(orderInfo, cancellationToken);

    [HttpGet("only")]
    public ValueTask<OrderInfo> GetOrderAsync([FromQuery] string myOrderDescription, CancellationToken cancellationToken = default) 
        => _orderService.GetOrderAsync(myOrderDescription, cancellationToken);

    [HttpPatch("des")]
    public ValueTask<bool> ChangeDescriptionAsync([FromQuery] string find, [FromBody] string newDescription, CancellationToken cancellationToken = default) 
        => _orderService.ChangeDescriptionAsync(find, newDescription, cancellationToken);

    [HttpDelete]
    public ValueTask<bool> DeleteOrderAsync([FromQuery] string forDelete, CancellationToken cancellationToken = default) 
        => _orderService.DeleteOrderAsync(forDelete, cancellationToken);

    [HttpPatch("state")]
    public ValueTask<bool> UpdateOrderStateAsync([FromQuery] int orderId, [FromBody] OrderState newOrderState, CancellationToken cancellationToken = default) 
        => _orderService.UpdateOrderStateAsync(orderId, newOrderState, cancellationToken);

    [HttpGet("count")]
    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default) 
        => _orderService.GetOrderCountAsync(cancellationToken);

}