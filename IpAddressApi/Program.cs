using FluentValidation;
using IpAddressApi.Api;
using IpAddressApi.Output;
using IpAddressApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Threading.Tasks;

namespace IpAddressApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfigurationRoot configuration = BuildConfiguration();
            ServiceProvider serviceProvider = BuildServiceProvider(configuration);

            var app = serviceProvider.GetRequiredService<IpAddressSearcApplication>();
            await app.RunAsync();
        }

        private static ServiceProvider BuildServiceProvider(
            IConfigurationRoot configuration)
        {
            var services = new ServiceCollection();
            ConfigureServices(configuration, services);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ConfigureServices(
            IConfigurationRoot configuration, 
            IServiceCollection services)
        {
            services.AddSingleton<IpAddressSearcApplication>();
            services.AddSingleton<IOutputWriter, OutputWriter>();
            services.AddSingleton<IIpAddressSearchService, IpAddressSearchService>();
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddRefitClient<IIpAddressApi>()
                .ConfigureHttpClient(httpClient =>
                {
                    httpClient.BaseAddress = new Uri(configuration["IpAddressApi:BaseAddress"]);
                });
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
