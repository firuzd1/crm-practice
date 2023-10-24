using System.Security.Cryptography.X509Certificates;
using Crm.DataAccess;

namespace Crm.BusinessLogic;


public sealed class StatisticsService : IStatisticsService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IClientRepository _clientRepository;

    public StatisticsService(IOrderRepository orderRepository, IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
        _orderRepository = orderRepository;
    }

    public ValueTask<int> GetClientsCountAsync(CancellationToken cancellationToken = default) => _clientRepository.GetClientCountAsync(cancellationToken);

    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default) => _orderRepository.GetOrderCountAsync(cancellationToken);

    public ValueTask<int> GetOrderCountAsync(string orderState, CancellationToken cancellationToken = default) => _orderRepository.GetOrderCountAsync(orderState.ToOrderEnum(), cancellationToken);


}