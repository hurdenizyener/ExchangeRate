using Business.Abstract;
using System.IO;
using System.Threading.Tasks;

namespace ServiceUI
{
    public class ExchangeRateService : BackgroundService ,IDisposable
    {

        private readonly IConfiguration _configuration;
        private readonly IFirstExchangeRateService _firstExchangeRateService;
        private readonly ISecondExchangeRateService _secondExchangeRateService;
        private readonly IThirdExchangeRateService _thirdExchangeRateService;
        private readonly IFourthExchangeRateService _fourthExchangeRateService;
        private readonly IFifthExchangeRateService _fifthExchangeRateService;
        private bool _disposed = false;

        public ExchangeRateService(
            IConfiguration configuration,
            IFirstExchangeRateService firstExchangeRateService,
            ISecondExchangeRateService secondExchangeRateService,
            IThirdExchangeRateService thirdExchangeRateService,
            IFourthExchangeRateService fourthExchangeRateService,
            IFifthExchangeRateService fifthExchangeRateService)
        {
            _configuration = configuration;
            _firstExchangeRateService = firstExchangeRateService;
            _secondExchangeRateService = secondExchangeRateService;
            _thirdExchangeRateService = thirdExchangeRateService;
            _fourthExchangeRateService = fourthExchangeRateService;
            _fifthExchangeRateService = fifthExchangeRateService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int databaseSettings = _configuration.GetValue<int>("DatabaseSettings");
            var path = _configuration.GetValue<string>("TcmbPath");
            int timeRange = _configuration.GetValue<int>("ClockSettings:TimeRange");
            TimeSpan startTime = _configuration.GetValue<TimeSpan>("ClockSettings:StartTime");
            TimeSpan endTime = _configuration.GetValue<TimeSpan>("ClockSettings:EndTime");
            var time = 0;

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

                Task myTask = Deneme();
                myTask.Wait();

                if (myTask.Status == TaskStatus.RanToCompletion || myTask.Status == TaskStatus.Faulted || myTask.Status == TaskStatus.Canceled)
                {
                    // dispose the task
                    myTask.Dispose();
                }
                else
                {
                    // handle the case where the task has not completed yet
                }




                //if (DateTime.Now.TimeOfDay >= startTime && DateTime.Now.TimeOfDay <= endTime)
                //{

                //    switch (databaseSettings)
                //    {
                //        case 1:
                //            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
                //            break;
                //        case 2:
                //            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _secondExchangeRateService.GetExchangeRateFromTCMB(path);
                //            break;
                //        case 3:
                //            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _secondExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _thirdExchangeRateService.GetExchangeRateFromTCMB(path);
                //            break;
                //        case 4:
                //            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _secondExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _thirdExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _fourthExchangeRateService.GetExchangeRateFromTCMB(path);
                //            break;
                //        case 5:
                //            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _secondExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _thirdExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _fourthExchangeRateService.GetExchangeRateFromTCMB(path);
                //            await _fifthExchangeRateService.GetExchangeRateFromTCMB(path);
                //            break;
                //        default:
                //            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
                //            break;

                           
                //    }

                    await Task.Delay(30000, stoppingToken);
                 


                //}
                //else
                //{
                //    Console.WriteLine("Şu anda kur kontrolü yapılamaz.");
                //}



             


                //  await Task.Delay(30000, stoppingToken);
                //Console.WriteLine("okey");
            }

            //  await _dovizKuruService.GetExchangeRateFromTCMB(path);


            throw new NotImplementedException();
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    var path = _configuration.GetValue<string>("TcmbPath");
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _firstExchangeRateService.GetExchangeRateFromTCMB(path).Dispose();
        //        }
        //        // dispose unmanaged resources
        //        _disposed = true;
        //    }
        //}

        public async Task Deneme()
        {
            var path = _configuration.GetValue<string>("TcmbPath");
            await _firstExchangeRateService.GetExchangeRateFromTCMB(path);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
         
            return base.StopAsync(cancellationToken);
        }

 

    }
}
