using Business;
using DataAccess;
using ServiceUI;
using Serilog;
using Serilog.Events;


IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddHttpClient();
        services.AddHostedService<ExchangeRateService>();
        services.AddDataAccessServices(configuration);
        services.AddBusinessServices();
    })
 .UseSerilog()
 .Build();

var configsetting = new ConfigurationBuilder().
       AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
.Enrich.FromLogContext()
.WriteTo.File(configsetting["Logging:Logpath"], rollingInterval: RollingInterval.Day)
.CreateLogger();




host.Run ();






