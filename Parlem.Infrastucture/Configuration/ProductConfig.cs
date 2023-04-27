using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parlem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Infrastructure.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(c => c.Id);

            builder.Property(p => p.ProductName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ProductTypeName)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.NumeracioTerminal)
                .HasMaxLength(15)
                .IsRequired();


        builder.HasData(
                    new Product
                    {
                        Id = 1111111,
                        ProductName = "FIBRA 1000 ADAMO",
                        ProductTypeName = "ftth",
                        NumeracioTerminal = 933933933,
                        SoldAt = DateTime.Now
                    },
                     new Product
                     {
                         Id = 2222222,
                         ProductName = "FIBRA 300 ADAMO",
                         ProductTypeName = "ftth",
                         NumeracioTerminal = 944944944,
                         SoldAt = DateTime.Now
                     }
                );
        }
    }
}
