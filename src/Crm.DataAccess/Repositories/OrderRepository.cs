
/*
namespace Crm.DataAccess;


public sealed class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders;
    private long _id = 0;

    public OrderRepository()
    {
        _orders = new List<Order>();
    }
    public bool Create(Order order)
    {
        if (order is not null)
        {
            _orders.Add(order);
            return true;
        }
        else return false;
    }

    public bool ChangeDescription(string find, string newDescription)
    {
        bool check = int.TryParse(find, out int id);
        if (!check)
            return false;

        Order? order = _orders.Find(o => o.Id.Equals(id));
        if (order is not null)
        {
            order.Description = newDescription;
            return true;
        }
        return false;
    }
    public Order GetOrder(string myOrderDescription)
    {
        if (myOrderDescription is not { Length: > 0 })
            throw new ArgumentNullException(nameof(myOrderDescription));

        Order? myOrder = _orders.Find(o => o.Description.Equals(myOrderDescription));
        {
            if (myOrder is not null)
            {
                return myOrder;
            }
        }
        return null;
    }

    public int GetOrderCount() => _orders.Count;
    public int GetOrderCount(OrderState orderState) => _orders.Count(o => o.MyOrderState.Equals(orderState));
    public bool UpdateOrderState(long orderId, OrderState orderState)
    {
        Order? order = _orders.Find(o => o.Id.Equals(orderId));
        if (order is null) return false;

        order.MyOrderState = orderState;
        return true;
    }
    public bool DeleteOrder(string forDelete)
    {
        bool idForDel = int.TryParse(forDelete, out int DelId);
        if (!idForDel)
            return false;

        Order? orderForDelete = _orders.Find(o => o.Id.Equals(DelId));

        if (orderForDelete != null)
            _orders.Remove(orderForDelete);
        return true;
    }
}
*/