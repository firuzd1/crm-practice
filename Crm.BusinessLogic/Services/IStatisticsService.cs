using Crm.DataAccess;

namespace Crm.BusinessLogic;


public interface IStatisticsService
{
    public ValueTask<int> GetClientsCountAsync(CancellationToken cancellationToken = default);
    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default);
    public ValueTask<int> GetOrderCountAsync(string orderState, CancellationToken cancellationToken = default);
}
