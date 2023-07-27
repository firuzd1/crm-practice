namespace Crm.Entities;

public sealed class Order
{
    public int OrderId { get; set; } // идентификатор заказа
    public string OrderDescription { get; set; } // описание заказа
    public decimal OrderPrice { get; set; } // цена заказа
    public DateTime OrderDate { get; set; } // дата заказа
    public DeliveryType OrderDeliveryType { get; set; } // тип доставки
    public string OrderDeliveryAddress { get; set; } // адрес доставки
}
