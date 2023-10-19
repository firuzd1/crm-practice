namespace Crm.DataAccess;

public readonly struct OrderInfo2
{
    public readonly int Id { get; init; }
    public readonly string Description { get; init; }
    public readonly decimal Price { get; init; }
    public readonly DateTime Date { get; init; }
    public readonly DeliveryType DeliveryType { get; init; }
    public readonly string DeliveryAddress { get; init; }
    public readonly OrderState NewOrderState { get; init; }
}