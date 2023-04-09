namespace Business.Abstract
{
    public interface IThirdExchangeRateService
    {

        Task GetExchangeRateFromTCMB(string path);
    }
}
