namespace Business.Abstract
{
    public interface ISecondExchangeRateService
    {
    
        Task GetExchangeRateFromTCMB(string path);
    }
}
