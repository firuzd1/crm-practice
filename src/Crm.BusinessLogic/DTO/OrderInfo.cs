namespace Crm.BusinessLogic;


public readonly record struct OrderInfo(
    long Id,
    string Description,
    decimal Price,
    DateTime Date,
    string DeliveryType,
    string DeliveryAddress,
    string NewOrderState
);