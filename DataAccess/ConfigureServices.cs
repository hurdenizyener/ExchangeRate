using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExchangeDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FirstConnectionString")), ServiceLifetime.Singleton);
            services.AddDbContext<FirstDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FirstConnectionString")), ServiceLifetime.Singleton);
            services.AddDbContext<SecondDbContext>(options => options.UseFirebird(configuration.GetConnectionString("SecondConnectionString")), ServiceLifetime.Singleton);
            services.AddDbContext<ThirdDbContext>(options => options.UseFirebird(configuration.GetConnectionString("ThirdConnectionString")), ServiceLifetime.Singleton);
            services.AddDbContext<FourthDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FourthConnectionString")), ServiceLifetime.Singleton);
            services.AddDbContext<FifthDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FifthConnectionString")), ServiceLifetime.Singleton);
        
            services.AddTransient<IFirstExchangeRateRepository, FirstExchangeRateRepository>();
            services.AddTransient<ISecondExchangeRateRepository, SecondExchangeRateRepository>();
            services.AddTransient<IThirdExchangeRateRepository, ThirdExchangeRateRepository>();
            services.AddTransient<IFourthExchangeRateRepository, FourthExchangeRateRepository>();
            services.AddTransient<IFifthExchangeRateRepository, FifthExchangeRateRepository>();
            services.AddTransient<IExchangeRepository, ExchangeRepository>();
            return services;
        }
    }
}
