using Business.Abstract;

namespace ServiceUI
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFirstExchangeRateService _dovizKuruService;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IFirstExchangeRateService dovizKuruService)
        {
            _logger = logger;
            _configuration = configuration;
            _dovizKuruService = dovizKuruService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int databaseSettings = _configuration.GetValue<int>("DatabaseSettings");
            var path = _configuration.GetValue<string>("TcmbPath");
            int timeRange = _configuration.GetValue<int>("ClockSettings:TimeRange");
            TimeSpan startTime = _configuration.GetValue<TimeSpan>("ClockSettings:StartTime");
            TimeSpan endTime = _configuration.GetValue<TimeSpan>("ClockSettings:EndTime");

            await _dovizKuruService.GetExchangeRateFromTCMB(path);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}