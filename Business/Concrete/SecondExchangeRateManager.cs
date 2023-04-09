using Business.Abstract;
using DataAccess.Repositories.Abstract;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class SecondExchangeRateManager : ISecondExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly ISecondExchangeRateRepository _secondExchangeRateRepository;

        public SecondExchangeRateManager(HttpClient httpClient , ISecondExchangeRateRepository secondExchangeRateRepository )
        {
            _httpClient = httpClient;
            _secondExchangeRateRepository = secondExchangeRateRepository;
           
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var xml = XDocument.Parse(content);

            Console.WriteLine(path);
            Console.WriteLine("2.manager");
        }
    }
}
