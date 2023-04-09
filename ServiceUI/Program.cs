using Business;
using DataAccess;
using ServiceUI;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddHttpClient();
        services.AddHostedService<ExchangeRateService>();
        services.AddDataAccessServices(configuration);
        services.AddBusinessServices();
    })
    .Build();

host.Run();
