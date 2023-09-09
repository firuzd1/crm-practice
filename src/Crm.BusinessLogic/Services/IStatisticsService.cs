using Crm.DataAccess;

namespace Crm.BusinessLogic;


public interface IStatisticsService
{
    public int GetClientsCount();
    public int GetOrderCount();
    public int GetOrderCount(OrderState orderState);
}
