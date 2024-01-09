using Crm.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Crm.DataAccess;

[ApiController]
[Route("statistic")]
public sealed class StatisticController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;
    public StatisticController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }
    [HttpGet("cientsCount")]
    public ValueTask<int> GetClientsCountAsync(CancellationToken cancellationToken = default) 
        => _statisticsService.GetClientsCountAsync(cancellationToken);

    [HttpGet("orderCount")]
    public ValueTask<int> GetOrderCountAsync(CancellationToken cancellationToken = default) 
        => _statisticsService.GetOrderCountAsync(cancellationToken);

    [HttpGet("ordersStates")]
    public ValueTask<int> GetOrderCountAsync([FromQuery] string orderState, CancellationToken cancellationToken = default) 
        => _statisticsService.GetOrderCountAsync(orderState, cancellationToken);
}