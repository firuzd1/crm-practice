using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.DataAccess;

public sealed partial class CrmDbContex
{
    public sealed class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder
            .HasKey(d => d.Id)
            .HasName("pk_id");

            builder
            .Property(d => d.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .IsRequired();

            builder
            .Property(d => d.DeliveryType)
            .HasColumnName("delivery-type")
            .IsRequired();

            builder
            .Property(d => d.Address)
            .HasColumnName("address")
            .IsRequired();

            builder
            .Property(d => d.Price)
            .HasColumnName("price")
            .HasColumnType("DECIMAL")
            .IsRequired();

            builder
            .Property(d => d.DeliveryDate)
            .HasColumnName("delivery-date")
            .IsRequired();

            builder.HasOne(o => o.Order)
            .WithOne(o => o.Delivery)
            .HasForeignKey<Order>(d => d.DeliveryId);
        }
    }
}

