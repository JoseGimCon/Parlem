using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parlem.Aplication.Interfaces;
using Parlem.Infrastructure.Context;
using Parlem.Infrastructure.Repositories;

namespace Parlem.Infrastructure
{
    public static class ServiceCollection
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ParlemDBContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."), b => b.MigrationsAssembly(typeof(ParlemDBContext).Assembly.FullName)));

            service.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));

        }
    }
}
