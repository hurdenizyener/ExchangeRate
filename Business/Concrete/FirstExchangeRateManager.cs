﻿using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class FirstExchangeRateManager : IFirstExchangeRateService
    {

        private readonly ILogger<FirstExchangeRateManager> _logger;
        private readonly HttpClient _httpClient;
        private readonly IFirstExchangeRateRepository _firstExchangeRateRepository;
        private readonly IFirstExchangeRateKnitRepository _firstExchangeRateKnitRepository;
        private readonly IFirstExchangeRepository _firstExchangeRepository;
        private readonly DateTime date = DateTime.Now.Date;
        private string currencyCode;
        private decimal forexBuying, forexSelling, banknoteBuying, banknoteSelling;


        public FirstExchangeRateManager(HttpClient httpClient, IFirstExchangeRateRepository firstExchangeRateRepository, IFirstExchangeRepository exchangeRepository, ILogger<FirstExchangeRateManager> logger, IFirstExchangeRateKnitRepository firstExchangeRateKnitRepository)
        {
            _httpClient = httpClient;
            _firstExchangeRateRepository = firstExchangeRateRepository;
            _firstExchangeRepository = exchangeRepository;
            _logger = logger;
            _firstExchangeRateKnitRepository = firstExchangeRateKnitRepository;
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            try
            {
                var response = await _httpClient.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Web Sitesi Bağlantısı Başarılı. Status Code {StatusCode}",response.StatusCode);
                }
                else
                {
                    _logger.LogInformation("Web Sitesi Bağlantısı Başarısız. Status Code {StatusCode}", response.StatusCode);
                }

                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var document = XDocument.Parse(content);
                List<ExchangeDto> exchange = await _firstExchangeRepository.GetAllAsync();

                if (exchange.Count > 0)
                {
                   
                    _logger.LogInformation($"1.Database de Toplam {exchange.Count} Adet Döviz Cinsi Bulundu");
                    foreach (var item in exchange)
                    {
                        _logger.LogInformation($"Doviz Cinsi: {item.DovizId}");
                    }
                }
                else
                {
                    _logger.LogInformation("1.Databese Döviz Tablosunda Kayıt Yok");
                }


                foreach (var currency in exchange)
                {

                    List<ExchangeRateDto> countExchangeRateByDate = await _firstExchangeRateRepository.GetAllAsync(p => p.Tarih == date && p.DovizId == currency.DovizId);
                 //   var countExchangeRateByDate = await _firstExchangeRateRepository.GetAllAsync();


                    if (countExchangeRateByDate.Count() > 0 )
                    {

                        switch (currency.DovizId)
                        {
                             
                            case "TL":
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

                _logger.LogError(ex.Message);
            }

        }

        public async Task AddAsync(string currency, XDocument document)
        {

            if (currency is "TL")
            {

                //await _firstExchangeRateRepository.AddAsync(new ExchangeRateDto()
                //{
                //    DovizId = currency,
                //    Tarih = DateTime.Now.Date,
                //    AlisFiati = 1,
                //    SatisFiati = 1,
                //    EfektifAlisFiati = 1,
                //    EfektifSatisFiati = 1,
                //    SerbestAlisFiati = 0,
                //    SerbestSatisFiati = 0,
                //    DegisimTarihi = DateTime.Now,
                //    InsertTarihi = DateTime.Now,
                //    InsertKullaniciId = 1,
                //    KullaniciId = 1
                //});
            }
            else
            {

                var node = document.Descendants("Currency").FirstOrDefault(x => x.Attribute("CurrencyCode").Value == currency);
                forexBuying = decimal.Parse(node.Element("ForexBuying").Value.Replace(".", ","));
                forexSelling = decimal.Parse(node.Element("ForexSelling").Value.Replace(".", ","));
                var banknoteBuyingControl = node.Element("BanknoteBuying").Value;
                banknoteBuying = banknoteBuyingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteBuying").Value.Replace(".", ","));
                var banknoteSellingControl = node.Element("BanknoteSelling").Value;
                banknoteSelling = banknoteSellingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteSelling").Value.Replace(".", ","));

                currencyCode = currency is "EUR" ? "EURO" : currency;

                await _firstExchangeRateRepository.AddAsync(new ExchangeRateDto()
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

                //await _firstExchangeRateKnitRepository.AddAsync(new ExchangeRateKnitDto()
                //{
                //    DovizId = currencyCode,
                //    Tarih = DateTime.Now.Date,
                //    AlisFiati = forexBuying,
                //    SatisFiati = forexSelling,
                //    EfektifAlisFiati = banknoteBuying,
                //    EfektifSatisFiati = banknoteSelling,
                //    SerbestAlisFiati = 0,
                //    SerbestSatisFiati = 0

                //});



                _logger.LogInformation($"1.Database {currencyCode} Kuru Eklendi. Alış Fiyatı: {forexBuying} , Satış Fiyatı: {forexSelling}");

            }
        }

        public async Task UpdateAsync(string currency, XDocument document)
        {
            currencyCode = currency is "EUR" ? "EURO" : currency;

            _logger.LogInformation($"1.Databese {currencyCode} Döviz Kontrolü Yapılıyor.");

            ExchangeRateDto exchangeRate = await _firstExchangeRateRepository.GetAsync(p => p.Tarih == date && p.DovizId == currencyCode);
            var node = document.Descendants("Currency").FirstOrDefault(x => x.Attribute("CurrencyCode").Value == currency);
            forexBuying = decimal.Parse(node.Element("ForexBuying").Value.Replace(".", ","));
            forexSelling = decimal.Parse(node.Element("ForexSelling").Value.Replace(".", ","));
            var banknoteBuyingControl = node.Element("BanknoteBuying").Value;
            banknoteBuying = banknoteBuyingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteBuying").Value.Replace(".", ","));
            var banknoteSellingControl = node.Element("BanknoteSelling").Value;
            banknoteSelling = banknoteSellingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteSelling").Value.Replace(".", ","));

            if (exchangeRate is null)
            {
                _logger.LogInformation($"1.Database {currencyCode} Kuruna Ait Kayıt Yok");
            }
            else
            {
             
                if (exchangeRate.AlisFiati != forexBuying || exchangeRate.SatisFiati != forexSelling)
                {
                    _logger.LogInformation($"1.Database {currencyCode} Kurunda Farklılık Var. Sistemde Olan Kur Alış Fiyatı: {exchangeRate.AlisFiati} - Gerçek Alış Kur Fiyatı: {forexBuying} / Sistemde Olan Kur Satış Fiyatı: {exchangeRate.SatisFiati} - Gerçek Satış Kur Fiyatı: {forexSelling}");

                    await _firstExchangeRateRepository.DeleteAsync(exchangeRate);
                   
                    await _firstExchangeRateRepository.AddAsync(new ExchangeRateDto()
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

                    _logger.LogInformation($"1.Database {currencyCode} Kuru Düzeltildi");
                }
                else
                {
                    _logger.LogInformation($"1.Database {currencyCode} Kur Fiyatında Farklılık Yok");
                }

            }
        }

    }
}
