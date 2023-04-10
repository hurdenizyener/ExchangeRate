using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IFirstExchangeRateService, FirstExchangeRateManager>();
            services.AddTransient<ISecondExchangeRateService, SecondExchangeRateManager>();
            services.AddTransient<IThirdExchangeRateService, ThirdExchangeRateManager>();
            services.AddTransient<IFourthExchangeRateService, FourthExchangeRateManager>();
            services.AddTransient<IFifthExchangeRateService, FifthExchangeRateManager>();
  
            return services;
        }
    }
}
