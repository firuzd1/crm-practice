using Crm.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.BusinessLogic;


public static class ServiceExtension
{
    public static void ConfigureCrmServices(this IServiceCollection services)
    {
        services.ConfigureDataAccess();
        services.AddTransient<IClientService, PostgreClientService>();
        services.AddTransient<IOrderService, PostgreOrderService>();
        services.AddTransient<IStatisticsService, StatisticsService>();
    }
}