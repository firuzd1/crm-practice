using Crm.Entities;

namespace Crm.Services;

public sealed class OrderService
{
    public Order CreateOrder(OrderInfo orderInfo
    )
    {
        return new()
        {
            OrderId = orderInfo.OrderId,
            OrderDescription = orderInfo.OrderDescription,
            OrderPrice = orderInfo.OrderPrice,
            OrderDate = orderInfo.OrderDate,
            OrderDeliveryType = orderInfo.OrderDeliveryType,
            OrderDeliveryAddress = orderInfo.OrderDeliveryAddress
        };
    }
}