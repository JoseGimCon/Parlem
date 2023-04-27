using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parlem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Infrastructure.Configuration
{
    public class CustomerProductConfig : IEntityTypeConfiguration<CustomerProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerProduct> builder)
        {
            builder.ToTable(nameof(CustomerProduct));

            builder.HasData(
                                new CustomerProduct
                                {
                                    CustomerId = 11111,
                                    ProductId = 1111111
                                },
                                 new CustomerProduct
                                 {
                                     CustomerId = 11111,
                                     ProductId = 2222222
                                 }
                            );

        }
    }
}
