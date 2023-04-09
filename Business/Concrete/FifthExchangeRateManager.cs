using Business.Abstract;
using DataAccess.Repositories.Abstract;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class FifthExchangeRateManager : IFifthExchangeRateService
    {

        private readonly HttpClient _httpClient;
        private readonly IFifthExchangeRateRepository _fifthExchangeRateRepository;

        public FifthExchangeRateManager(HttpClient httpClient, IFifthExchangeRateRepository fifthExchangeRateRepository)
        {
            _httpClient = httpClient;
            _fifthExchangeRateRepository = fifthExchangeRateRepository;
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(content);

            Console.WriteLine(path);
            Console.WriteLine("5.manager");
        }
    }
}
