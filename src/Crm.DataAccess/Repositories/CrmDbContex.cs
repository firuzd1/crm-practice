using Microsoft.EntityFrameworkCore;

namespace Crm.DataAccess;

public sealed partial class CrmDbContex : DbContext
{
    public CrmDbContex(DbContextOptions<CrmDbContex> options)
        :base(options)
    {}
    public DbSet<Order> order { get; set; }
    public DbSet<Client> client { get; set; }
    public DbSet<Delivery> deliveries { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryConfiguration());
    }
}

