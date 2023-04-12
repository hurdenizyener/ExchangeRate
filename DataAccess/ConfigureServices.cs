using DataAccess.Contexts;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<FirstDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FirstConnectionString")));
            services.AddDbContext<SecondDbContext>(options => options.UseFirebird(configuration.GetConnectionString("SecondConnectionString")));
            services.AddDbContext<ThirdDbContext>(options => options.UseFirebird(configuration.GetConnectionString("ThirdConnectionString")));
            services.AddDbContext<FourthDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FourthConnectionString")));
            services.AddDbContext<FifthDbContext>(options => options.UseFirebird(configuration.GetConnectionString("FifthConnectionString")));

            services.AddTransient<IFirstExchangeRateRepository, FirstExchangeRateRepository>();
            services.AddTransient<IFirstExchangeRateKnitRepository, FirstExchangeRateKnitRepository>();
            services.AddTransient<IFirstExchangeRepository, FirstExchangeRepository>();
            services.AddTransient<ISecondExchangeRateRepository, SecondExchangeRateRepository>();
            services.AddTransient<ISecondExchangeRepository, SecondExchangeRepository>();
            services.AddTransient<IThirdExchangeRateRepository, ThirdExchangeRateRepository>();
            services.AddTransient<IThirdExchangeRepository, ThirdExchangeRepository>();
            services.AddTransient<IFourthExchangeRateRepository, FourthExchangeRateRepository>();
            services.AddTransient<IFourthExchangeRepository, FourthExchangeRepository>();
            services.AddTransient<IFifthExchangeRateRepository, FifthExchangeRateRepository>();
            services.AddTransient<IFifthExchangeRepository, FifthExchangeRepository>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
