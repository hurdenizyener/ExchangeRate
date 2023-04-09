using Business.Abstract;
using DataAccess.Repositories.Abstract;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class ThirdExchangeRateManager : IThirdExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly IThirdExchangeRateRepository _thirdExchangeRateRepository;

        public ThirdExchangeRateManager(HttpClient httpClient, IThirdExchangeRateRepository thirdExchangeRateRepository)
        {
            _httpClient = httpClient;
            _thirdExchangeRateRepository = thirdExchangeRateRepository;
           
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(content);

            Console.WriteLine(path);
            Console.WriteLine("3.manager");
        }
    }
}
