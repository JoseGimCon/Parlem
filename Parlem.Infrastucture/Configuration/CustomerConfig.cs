using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parlem.Domain.Entities;

namespace Parlem.Infrastructure.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(c => c.Id);

            builder.Property(p => p.DocType)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(p => p.DocNum)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.GivenName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.FamilyName1)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasMaxLength(9)
            .IsRequired();

            builder.HasData(
                    new Customer
                    {
                         Id = 11111,
                         DocType = "nif",
                         DocNum = "11223344E",
                         Email = "it@parlem.com",
                         GivenName = "Enriqueta",
                         FamilyName1 = "Parlem",
                         Phone = "668668668"
                    },
                     new Customer
                     {
                         Id = 22222,
                         DocType = "nie",
                         DocNum = "Z3332628W",
                         Email = "rh@parlem.com",
                         GivenName = "Joana",
                         FamilyName1 = "Parlem",
                         Phone = "697923421"
                     }
                );
        }
    }
}
