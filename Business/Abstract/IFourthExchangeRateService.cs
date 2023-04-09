namespace Business.Abstract
{
    public interface IFourthExchangeRateService
    {
        Task GetExchangeRateFromTCMB(string path);
    }
}
