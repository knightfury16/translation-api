using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using translation.application.Common.Interfaces;
using translation.infrastructure.TranslatorServices;

namespace translation.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITranslatorService, TranslatorService>();
            services.AddSingleton<IAvailableLanguage, AvailableLanguage>();

            return services;
        }
    }
}
