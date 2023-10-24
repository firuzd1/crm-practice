using Microsoft.EntityFrameworkCore;

namespace Crm.DataAccess;

public sealed partial class CrmDbContex : DbContext
{
    public DbSet<Order> order { get; set; }
    public DbSet<Client> client { get; set; }
    public DbSet<Delivery> deliveries { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(optionsBuilder.IsConfigured)
            return;

        optionsBuilder.UseNpgsql(DatabaseHelper.ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryConfiguration());
    }
}

