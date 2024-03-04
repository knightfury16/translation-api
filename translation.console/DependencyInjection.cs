using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.application;
using translation.infrastructure;

namespace translation.console
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices();

            return services;
        }
    }
}
