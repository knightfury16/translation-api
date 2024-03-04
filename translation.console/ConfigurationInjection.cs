using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace translation.console
{
    public static class ConfigurationInjection
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {

            IConfiguration configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                Build();

            services.AddSingleton<IConfiguration>(configuration);

            return services;

        }
    }
}
