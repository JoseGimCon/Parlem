using Microsoft.EntityFrameworkCore;
using Parlem.Aplication.Interfaces;
using Parlem.Domain.Common;
using Parlem.Domain.Entities;
using System.Reflection;

namespace Parlem.Infrastructure.Context
{
    public class ParlemDBContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        public ParlemDBContext(DbContextOptions<ParlemDBContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.CreateTime;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.CreateTime;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Customer>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Customers)
            .UsingEntity<CustomerProduct>();


            modelBuilder.Entity<CustomerProduct>().Navigation(x => x.Product).AutoInclude(true);
            modelBuilder.Entity<CustomerProduct>().Navigation(x => x.Customer).AutoInclude(true);
            modelBuilder.Entity<Customer>().Navigation(x => x.Products).AutoInclude(true);


        }
    }
}
