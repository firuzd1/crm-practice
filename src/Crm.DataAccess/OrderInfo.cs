namespace Crm.DataAccess;

public readonly struct OrderInfo
{
    public readonly int OrderId { get; init; }
    public readonly string OrderDescription { get; init; }
    public readonly decimal OrderPrice { get; init; }
    public readonly DateTime OrderDate {get; init; }
    public readonly DeliveryType OrderDeliveryType { get; init; }
    public readonly string OrderDeliveryAddress { get; init; }
    public readonly OrderState NewOrderState { get; init; }
}