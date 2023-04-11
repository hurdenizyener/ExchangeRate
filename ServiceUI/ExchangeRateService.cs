using Business.Abstract;
using Business.Concrete;

namespace ServiceUI
{
    public class ExchangeRateService : BackgroundService
    {

        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(
            IConfiguration configuration,
            IServiceScopeFactory serviceScopeFactory,
            ILogger<ExchangeRateService> logger)
        {
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hizmet Başlatıldı.");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int test = _configuration.GetValue<int>("Test");
            int databaseSettings = _configuration.GetValue<int>("DatabaseSettings");
            var path = _configuration.GetValue<string>("TcmbPath");
            int timeRange = _configuration.GetValue<int>("ClockSettings:TimeRange");
            TimeSpan startTime = _configuration.GetValue<TimeSpan>("ClockSettings:StartTime");
            TimeSpan endTime = _configuration.GetValue<TimeSpan>("ClockSettings:EndTime");
            var time = 0;


            _logger.LogInformation($"Hizmet {startTime} - {endTime} Saatleri Arasında Çalışacak");
            _logger.LogInformation($"Hizmet {timeRange} Saatte 1 Defa İşlem Yapacak");

            try
            {

          

            switch (timeRange)
            {
                case 1:
                    time = 3600000;
                    break;
                case 2:
                    time = 3600000 * 2;
                    break;
                case 3:
                    time = 3600000 * 3;
                    break;
                case 4:
                    time = 3600000 * 4;
                    break;
                case 5:
                    time = 3600000 * 5;
                    break;
                case 6:
                    time = 3600000 * 6;
                    break;
                default:
                    time = 3600000;
                    break;
            }

            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var firstExchangeRateService = scope.ServiceProvider.GetRequiredService<IFirstExchangeRateService>();
                    var secondExchangeRateService = scope.ServiceProvider.GetRequiredService<ISecondExchangeRateService>();
                    var thirdExchangeRateService = scope.ServiceProvider.GetRequiredService<IThirdExchangeRateService>();
                    var fourthExchangeRateService = scope.ServiceProvider.GetRequiredService<IFourthExchangeRateService>();
                    var fifthExchangeRateService = scope.ServiceProvider.GetRequiredService<IFifthExchangeRateService>();


                    if (DateTime.Now.TimeOfDay >= startTime && DateTime.Now.TimeOfDay <= endTime)
                    {

                        switch (databaseSettings)
                        {
                            case 1:
                                await firstExchangeRateService.GetExchangeRateFromTCMB(path);
                                break;
                            case 2:
                                await firstExchangeRateService.GetExchangeRateFromTCMB(path);
                                await secondExchangeRateService.GetExchangeRateFromTCMB(path);
                                break;
                            case 3:
                                await firstExchangeRateService.GetExchangeRateFromTCMB(path);
                                await secondExchangeRateService.GetExchangeRateFromTCMB(path);
                                await thirdExchangeRateService.GetExchangeRateFromTCMB(path);
                                break;
                            case 4:
                                await firstExchangeRateService.GetExchangeRateFromTCMB(path);
                                await secondExchangeRateService.GetExchangeRateFromTCMB(path);
                                await thirdExchangeRateService.GetExchangeRateFromTCMB(path);
                                await fourthExchangeRateService.GetExchangeRateFromTCMB(path);
                                break;
                            case 5:
                                await firstExchangeRateService.GetExchangeRateFromTCMB(path);
                                await secondExchangeRateService.GetExchangeRateFromTCMB(path);
                                await thirdExchangeRateService.GetExchangeRateFromTCMB(path);
                                await fourthExchangeRateService.GetExchangeRateFromTCMB(path);
                                await fifthExchangeRateService.GetExchangeRateFromTCMB(path);
                                break;
                            default:
                                await firstExchangeRateService.GetExchangeRateFromTCMB(path);
                                break;
                        }

                        switch (test)
                        {
                            case 0:
                                await Task.Delay(20000, stoppingToken);
                                _logger.LogInformation("Hizmet Test Modunda Çalıştırıldı 20 Saniyede Bir Çalışacaktır");
                                break;
                            case 1:
                                await Task.Delay(time, stoppingToken);
                               
                                break;
                            default:
                                await Task.Delay(time, stoppingToken);
                                break;
                        }
                       
                    }
                }
            }

            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex , ex.Message);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hizmet Kapatıldı.");
            return base.StopAsync(cancellationToken);
        }

    }
}
