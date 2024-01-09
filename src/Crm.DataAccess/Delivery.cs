using System.ComponentModel.DataAnnotations.Schema;

namespace Crm.DataAccess;

[Table("delivery")]
public sealed class Delivery
{
    public long Id { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public DateTime DeliveryDate{ get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
}