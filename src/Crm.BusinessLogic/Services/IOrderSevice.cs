using Crm.DataAccess;
namespace Crm.BusinessLogic;


interface IOrderService
{
    public Order CreateOrder(OrderInfo orderInfo);
    public Order GetOrder(string myOrderDescription);
    public Order? ChangeDescription(string find, string newDescription);
    public void DeleteOrder(string forDelete); 
    public bool ChangeState(string id, string index);
    public int OrderStat();
    public int PendingStatistics();
    public int ApprovedStatistics();
    public int CancelledStatistics();

}