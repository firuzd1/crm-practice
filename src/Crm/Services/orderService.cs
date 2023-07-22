using Crm.Entities;

namespace Crm.Services;

public sealed class OrderService
{
    public Order CreateOrder(
    int orderId,
    string orderDescription,
    decimal orderPrice,
    DateTime orderDate,
    string orderDeliveryType,
    string orderDeliveryAddress
    )
    {
        return new()
        {
            OrderId = orderId,
            OrderDescription = orderDescription,
            OrderPrice = orderPrice,
            OrderDate = orderDate,
            OrderDeliveryType = orderDeliveryType,
            OrderDeliveryAddress = orderDeliveryAddress
        };
    }
}