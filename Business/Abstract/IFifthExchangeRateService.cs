namespace Business.Abstract
{
    public interface IFifthExchangeRateService
    {
        Task GetExchangeRateFromTCMB(string path);
    }
}
