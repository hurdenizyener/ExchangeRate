using Business.Abstract;
using DataAccess.Repositories.Abstract;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class FourthExchangeRateManager : IFourthExchangeRateService
    {

        private readonly HttpClient _httpClient;
        private readonly IFourthExchangeRateRepository _fourthExchangeRateRepository;

        public FourthExchangeRateManager(HttpClient httpClient, IFourthExchangeRateRepository fourthExchangeRateRepository)
        {
            _httpClient = httpClient;
            _fourthExchangeRateRepository = fourthExchangeRateRepository;
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(content);

            Console.WriteLine(path);
            Console.WriteLine("4.manager");
        }
    }
}
