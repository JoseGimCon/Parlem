using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parlem.Aplication.Interfaces;
using Parlem.Infrastructure;
using Parlem.Infrastructure.Services;

namespace Parlem.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
