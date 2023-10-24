using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.DataAccess;

public sealed partial class CrmDbContex
{
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
            .HasKey(p => p.Id)
            .HasName("pk_id");

            builder
            .Property(p => p.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .IsRequired();


            builder
            .Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("TEXT")
            .IsRequired();

            builder
            .Property(p => p.Price)
            .HasColumnName("price")
            .HasColumnType("DECIMAL")
            .IsRequired();
            
            builder
            .Property(p => p.Date)
            .HasColumnName("create-at")
            .IsRequired();
            
            builder
            .Property(p => p.DeliveryAddress)
            .HasColumnName("delivery-address")
            .IsRequired();

            builder
            .Property(p => p.DeliveryType)
            .HasColumnName("delivery-type")
            .IsRequired();

            builder
            .Property(p => p.MyOrderState)
            .HasColumnName("order-state")
            .IsRequired();

            builder
            .HasOne(c => c.Client)
            .WithMany(c => c.Orders)
            .IsRequired();

            builder
            .HasOne(d => d.Delivery)
            .WithOne(d => d.Order)
            .HasForeignKey<Delivery>(d => d.OrderId);
        }
    }
}

