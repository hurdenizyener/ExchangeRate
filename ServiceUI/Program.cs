using Business;
using DataAccess;
using ServiceUI;
using Serilog;
using Serilog.Events;


public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.File(@"C:\Logs\EgemenKurLogs\Log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

        try
        {
            Log.Information("Hizmet Baþlatýldý.");
            CreateHostBuilder(args).Build().Run();
            return;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Hizmeti Baþlatýrken Bir Sorun Oluþtu.");
            return;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;
                services.AddHttpClient();
                services.AddHostedService<ExchangeRateService>();
                services.AddDataAccessServices(configuration);
                services.AddBusinessServices();
            })
         .UseSerilog();
    }
}



