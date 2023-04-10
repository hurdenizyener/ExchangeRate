using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Entities;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class FourthExchangeRateManager : IFourthExchangeRateService
    {

        private readonly HttpClient _httpClient;
        private readonly IFourthExchangeRateRepository _fourthExchangeRateRepository;
        private readonly IFourthExchangeRepository _fourthExchangeRepository;
        private readonly DateTime date = DateTime.Now.Date;
        private string currencyCode;
        private decimal forexBuying, forexSelling, banknoteBuying, banknoteSelling;

        public FourthExchangeRateManager(HttpClient httpClient, IFourthExchangeRateRepository fourthExchangeRateRepository, IFourthExchangeRepository fourthExchangeRepository)
        {
            _httpClient = httpClient;
            _fourthExchangeRateRepository = fourthExchangeRateRepository;
            _fourthExchangeRepository = fourthExchangeRepository;
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            try
            {
                var response = await _httpClient.GetAsync(path);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var document = XDocument.Parse(content);
                List<Exchange> exchange = await _fourthExchangeRepository.GetAllAsync();
                foreach (var currency in exchange)
                {

                    var countExchangeRateByDate = await _fourthExchangeRateRepository.GetAllAsync(p => p.Tarih == date && p.DovizId == currency.DovizId);


                    if (countExchangeRateByDate.Count() > 0)
                    {
                        switch (currency.DovizId)
                        {
                            case "TL":
                                Console.WriteLine("Türk Lirası Kayıtlı Fiyat Kontrolü Yapılmayacak");
                                break;
                            case "EURO":
                                currencyCode = "EUR";
                                await UpdateAsync(currencyCode, document);

                                break;
                            default:
                                await UpdateAsync(currency.DovizId, document);

                                break;
                        }
                    }
                    else
                    {
                        switch (currency.DovizId)
                        {
                            case "TL":
                                await AddAsync(currency.DovizId, document);
                                break;
                            case "EURO":
                                currencyCode = "EUR";
                                await AddAsync(currencyCode, document);
                                break;
                            default:
                                await AddAsync(currency.DovizId, document);
                                break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public async Task AddAsync(string currency, XDocument document)
        {
            if (currency is "TL")
            {

                await _fourthExchangeRateRepository.AddAsync(new ExchangeRate()
                {
                    DovizId = currency,
                    Tarih = DateTime.Now.Date,
                    AlisFiati = 1,
                    SatisFiati = 1,
                    EfektifAlisFiati = 1,
                    EfektifSatisFiati = 1,
                    SerbestAlisFiati = 0,
                    SerbestSatisFiati = 0,
                    DegisimTarihi = DateTime.Now,
                    InsertTarihi = DateTime.Now,
                    InsertKullaniciId = 1,
                    KullaniciId = 1
                });
            }
            else
            {

                var node = document.Descendants("Currency").FirstOrDefault(x => x.Attribute("CurrencyCode").Value == currency);
                forexBuying = decimal.Parse(node.Element("ForexBuying").Value.Replace(".", ","));
                forexSelling = decimal.Parse(node.Element("ForexSelling").Value.Replace(".", ","));
                var denem = node.Element("BanknoteBuying").Value;
                banknoteBuying = denem is "" ? 0 : decimal.Parse(node.Element("BanknoteBuying").Value.Replace(".", ","));
                var denem2 = node.Element("BanknoteSelling").Value;
                banknoteSelling = denem2 is "" ? 0 : decimal.Parse(node.Element("BanknoteSelling").Value.Replace(".", ","));
                currencyCode = currency is "EUR" ? "EURO" : currency;



                await _fourthExchangeRateRepository.AddAsync(new ExchangeRate()
                {
                    DovizId = currencyCode,
                    Tarih = DateTime.Now.Date,
                    AlisFiati = forexBuying,
                    SatisFiati = forexSelling,
                    EfektifAlisFiati = banknoteBuying,
                    EfektifSatisFiati = banknoteSelling,
                    SerbestAlisFiati = 0,
                    SerbestSatisFiati = 0,
                    DegisimTarihi = DateTime.Now,
                    InsertTarihi = DateTime.Now,
                    InsertKullaniciId = 1,
                    KullaniciId = 1
                });

                Console.WriteLine(currencyCode + "eklendi");

            }
        }

        public async Task UpdateAsync(string currency, XDocument document)
        {
            currencyCode = currency is "EUR" ? "EURO" : currency;
            ExchangeRate exchangeRate = await _fourthExchangeRateRepository.GetAsync(p => p.Tarih == date && p.DovizId == currencyCode);
            var node = document.Descendants("Currency").FirstOrDefault(x => x.Attribute("CurrencyCode").Value == currency);
            forexBuying = decimal.Parse(node.Element("ForexBuying").Value.Replace(".", ","));
            forexSelling = decimal.Parse(node.Element("ForexSelling").Value.Replace(".", ","));
            var denem = node.Element("BanknoteBuying").Value;
            banknoteBuying = denem is "" ? 0 : decimal.Parse(node.Element("BanknoteBuying").Value.Replace(".", ","));
            var denem2 = node.Element("BanknoteSelling").Value;
            banknoteSelling = denem2 is "" ? 0 : decimal.Parse(node.Element("BanknoteSelling").Value.Replace(".", ","));

            if (exchangeRate is null)
            {
                Console.WriteLine("Bu Kura Ait Kayıt Yok");
            }
            else
            {

                Console.WriteLine("Kod= " + currencyCode + "Veritabanı Kur= " + exchangeRate.AlisFiati + "Kur Fiyatı= " + forexBuying);



                if (exchangeRate.AlisFiati != forexBuying || exchangeRate.SatisFiati != forexSelling)
                {
                    Console.WriteLine("Fiyatta Farklılık Var");
                    await _fourthExchangeRateRepository.DeleteAsync(exchangeRate);
                    Console.WriteLine("Farklı Olan Kur Silindi");
                    await _fourthExchangeRateRepository.AddAsync(new ExchangeRate()
                    {
                        DovizId = exchangeRate.DovizId,
                        Tarih = exchangeRate.Tarih,
                        AlisFiati = forexBuying,
                        SatisFiati = forexSelling,
                        EfektifAlisFiati = exchangeRate.EfektifAlisFiati,
                        EfektifSatisFiati = exchangeRate.EfektifSatisFiati,
                        SerbestAlisFiati = exchangeRate.SerbestAlisFiati,
                        SerbestSatisFiati = exchangeRate.SerbestSatisFiati,
                        DegisimTarihi = DateTime.Now,
                        InsertTarihi = DateTime.Now,
                        InsertKullaniciId = 1,
                        KullaniciId = 1
                    });

                    Console.WriteLine(exchangeRate.DovizId + forexBuying + forexSelling + "Yenisi Eklendi");
                }
                else
                {
                    Console.WriteLine("Fiyatlar aynı sorun yok ");
                }

            }
        }
    }
}
