using System.Xml.Linq;

namespace Business.Abstract
{
    public interface IFourthExchangeRateService
    {
        Task AddAsync(string currency, XDocument document);

        Task UpdateAsync(string currency, XDocument document);

        Task GetExchangeRateFromTCMB(string path);
    }
}
