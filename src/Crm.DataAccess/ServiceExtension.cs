using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.DataAccess;


public static class ServiceExtension
{
    public static void ConfigureDataAccess(this IServiceCollection services)
    {
        services.AddDbContext<CrmDbContex>(
            opt => opt.UseNpgsql(DatabaseHelper.ConnectionString)
        );

        services.AddScoped<IClientRepository, EfcoreClientRepository>();
        services.AddScoped<IOrderRepository, EfcoreOrderRepository>();
    }
}