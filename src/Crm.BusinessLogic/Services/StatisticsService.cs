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

    public int GetClientsCount() => _clientRepository.GetClientCount();

    public int GetOrderCount() => _orderRepository.GetOrderCount();

    public int GetOrderCount(string orderState) => _orderRepository.GetOrderCount(orderState.ToOrderEnum());


}