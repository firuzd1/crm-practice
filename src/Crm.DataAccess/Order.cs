using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Crm.DataAccess;

[Table("order")]
public sealed class Order
{
    private long _orderId;
    private string? orderDescription;
    private decimal orderPrise;
    private string? _orderDeliveryAddress;
    private OrderState _orderState;

    public required long Id 
    { 
        get
        {
            if(_orderId == null)
                throw new ArgumentNullException(nameof(_orderId));
            else return _orderId;
        }
        set
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

    public string Description 
    {
        get => orderDescription ?? string.Empty;
        set => orderDescription = value is {Length: < 2} ? throw new Exception("Описание не может содержать один символ!") : orderDescription = value;
    }

    public decimal Price 
    {
        get => orderPrise;
        init => orderPrise = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DateTime Date { get; set; }

    public required DeliveryType DeliveryType { get; init; }

    public required string DeliveryAddress
    {
        get => _orderDeliveryAddress ?? string.Empty;
        init => _orderDeliveryAddress = value is {Length: >= 0} ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
   public required OrderState MyOrderState{ get; set; }
   public long DeliveryId { get; set; }
   public Client Client { get; set; }
   public Delivery Delivery { get; set; }
}


