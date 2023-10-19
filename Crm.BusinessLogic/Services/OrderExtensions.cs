namespace Crm.BusinessLogic;
using Crm.DataAccess;

public static class OrderExtensions
{
    public static DeliveryType ToDeliveryEnum(this string DeliveryStr)
    => Enum.Parse<DeliveryType>(DeliveryStr);

    public static OrderState ToOrderEnum(this string OrderStateStr)
    => Enum.Parse<OrderState>(OrderStateStr);

    public static OrderInfo ToOrderInfo(this Order order)
    {
        OrderInfo orderInfo = new(
        order.Id,
        order.Description,
        order.Price,
        order.Date,
        order.DeliveryType.ToString(),
        order.DeliveryAddress,
        order.MyOrderState.ToString());
        return orderInfo;
    }
}