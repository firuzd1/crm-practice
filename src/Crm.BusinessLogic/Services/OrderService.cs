using Crm.DataAccess;
namespace Crm.BusinessLogic;

public sealed class OrderService : IOrderService
{
    private readonly List<Order> _orderList = new List<Order>();
    public Order CreateOrder(OrderInfo orderInfo)
    {
        Order newOrder = new Order()
        {
            OrderId = orderInfo.OrderId,
            OrderDescription = orderInfo.OrderDescription,
            OrderPrice = orderInfo.OrderPrice,
            OrderDate = orderInfo.OrderDate,
            OrderDeliveryType = orderInfo.OrderDeliveryType,
            OrderDeliveryAddress = orderInfo.OrderDeliveryAddress,
            MyOrderState = orderInfo.NewOrderState
        };
        _orderList.Add(newOrder);
        return newOrder;
    }
    public Order GetOrder(string myOrderDescription)
    {
        if (myOrderDescription is not { Length: > 0 })
            throw new ArgumentNullException(nameof(myOrderDescription));
 
        foreach (Order myOrder in _orderList)
        {
            if (myOrder.orderDescription.Equals(myOrderDescription))
            {
                return myOrder;
            }
        }
        return null;
    }
    public Order? ChangeDescription(string find, string newDescription)
    {
        bool check = int.TryParse(find, out int id);
        if(!check)
            throw new Exception("Введены не верные данные!");

        foreach(Order order in _orderList)
        {
            if(order.OrderId.Equals(id))
            {
                
                order.OrderDescription = newDescription;
                return order;
            }
        }
        return null;
    }
    public void DeleteOrder(string forDelete)
    {
        bool idForDel = int.TryParse(forDelete, out int DelId);
        if(!idForDel)
            throw new ArgumentNullException(nameof(forDelete));
        Order orderForDelete = null;
        
        foreach(Order order in _orderList)
        {
            if(order.OrderId == DelId)
            {
                orderForDelete = order;
            }
        }
        if(orderForDelete != null)
            _orderList.Remove(orderForDelete);
    }
    public bool ChangeState(string id, string index)
    {
        int number = int.Parse(index);
        bool myId = int.TryParse(id, out int found);
        if(!myId)
            throw new ArgumentNullException(nameof(id));
        Order forChange = null;
        foreach(Order search in _orderList)
        {
            if(search.OrderId.Equals(found))
            {
                forChange = search;
            }
        }
        if(forChange.MyOrderState != null)
        {
            OrderState orderState1 = (OrderState)number;
            forChange.MyOrderState = orderState1;
            return true;
        }
        return false;
    }
    public int OrderStat()
    {
        int count = 0;
        foreach(Order orderRegis in _orderList)
            count++;

        return count;
    }
    public int PendingStatistics()
    {
        int count = 0;
        foreach (Order pending in _orderList)
        {
            if(pending.MyOrderState == OrderState.Pending)
                count++;
        }
        return count;
    }
    public int ApprovedStatistics()
    {
       int count = 0;
        foreach (Order approved in _orderList)
        {
            if(approved.MyOrderState == OrderState.Pending)
                count++;
        }
        return count;
    }
    public int CancelledStatistics()
    {
       int count = 0;
        foreach (Order cancelled in _orderList)
        {
            if(cancelled.MyOrderState == OrderState.Pending)
                count++;
        }
        return count;
    }
}