using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crm.DataAccess;

public sealed partial class CrmDbContex
{
    public sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> modelBuilder)
        {
            modelBuilder
            .HasKey(p => p.Id)
            .HasName("pk_id");

            modelBuilder
            .Property(p => p.Id)
            .HasColumnType("SERIAL")
            .HasColumnName("id")
            .IsRequired();

            modelBuilder
            .Property(p => p.FirstName)
            .HasColumnName("first-name")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

            modelBuilder
            .Property(p => p.LastName)
            .HasColumnName("last-name")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

            modelBuilder
            .Property(p => p.MiddleName)
            .HasColumnName("middle-name")
            .HasColumnType("VARCHAR(20)");

            modelBuilder
            .Property(p => p.Age)
            .HasColumnName("age")
            .HasColumnType("INTEGER")
            .IsRequired();

            modelBuilder
            .Property(p => p.PassportNumber)
            .HasColumnName("passport-name")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

             modelBuilder
            .Property(p => p.Gender)
            .HasColumnName("gender")
            .IsRequired();

            modelBuilder
            .Property(p => p.UserPhone)
            .HasColumnName("phone")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

            modelBuilder
            .Property(p => p.UserEmail)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

            modelBuilder
            .Property(p => p.UserPassword)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(64)");

            modelBuilder
            .HasMany(o => o.Orders)
            .WithOne(o => o.Client);

        }
    }
}

