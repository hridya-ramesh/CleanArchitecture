using Challenge_API.Application.Interfaces;
using Challenge_API.Infrastructure.WooliesX;
using Challenge_API.Infrastructure.WooliesX.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_API.Infrastructure
{
    public static class DependancyInjection
    {
        private const string apiSectionName = "WooliesAPI";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IWooliesXProductService, WooliesXProductsService>();
            services.Configure<WooliesAPI>(config?.GetSection(apiSectionName));
            return services;
        }
    }
}
