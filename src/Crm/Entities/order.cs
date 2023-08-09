namespace Crm.Entities;

public sealed class Order
{
    private int _orderId;
    public string? orderDescription;
    public decimal orderPrise;
    private string? _orderDeliveryAddress;
    public required int OrderId 
    { 
        get
        {
            if(_orderId == null)
                throw new ArgumentNullException(nameof(_orderId));
            else return _orderId;
        }
        init
        {
            if(_orderId < 0)
            {
                throw new Exception("Ордер не может быть нулевым!");
            }
            else if(_orderId == null)
                throw new ArgumentNullException(nameof(value));
            else _orderId = value;
        }
    }
    public string OrderDescription 
    {
        get => orderDescription ?? string.Empty;
        set => orderDescription = value is {Length: < 2} ? throw new Exception("Описание не может содержать один символ!") : orderDescription = value;
    }
    public decimal OrderPrice 
    {
        get => orderPrise;
        init => orderPrise = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public DateTime OrderDate { get; set; }
    public required DeliveryType OrderDeliveryType { get; init; }
    public required string OrderDeliveryAddress
    {
        get => _orderDeliveryAddress ?? string.Empty;
        init => _orderDeliveryAddress = value is {Length: >= 0} ? value : throw new ArgumentOutOfRangeException(nameof(value));
    } 
}
