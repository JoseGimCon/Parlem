﻿using Microsoft.AspNetCore.Mvc;

namespace Parlem.Service.Extensions
{
    public static class ServiceExtension
    {
        public static void AddApiVersioningExtension(this IServiceCollection services) 
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);

                config.AssumeDefaultVersionWhenUnspecified = true;

                config.ReportApiVersions = true;
            });
        }
    }
}
