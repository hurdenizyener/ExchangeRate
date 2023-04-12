﻿using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Entities;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class SecondExchangeRateManager : ISecondExchangeRateService
    {
        private readonly ILogger<SecondExchangeRateManager> _logger;
        private readonly HttpClient _httpClient;
        private readonly ISecondExchangeRateRepository _secondExchangeRateRepository;
        private readonly ISecondExchangeRepository _secondExchangeRepository;
        private readonly DateTime date = DateTime.Now.Date;
        private string currencyCode;
        private decimal forexBuying, forexSelling, banknoteBuying, banknoteSelling;

        public SecondExchangeRateManager(HttpClient httpClient, ISecondExchangeRateRepository secondExchangeRateRepository, ISecondExchangeRepository secondExchangeRepository, ILogger<SecondExchangeRateManager> logger)
        {
            _httpClient = httpClient;
            _secondExchangeRateRepository = secondExchangeRateRepository;
            _secondExchangeRepository = secondExchangeRepository;
            _logger = logger;
        }

        public async Task GetExchangeRateFromTCMB(string path)
        {
            //try
            //{
            //    var response = await _httpClient.GetAsync(path);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        _logger.LogInformation("Web Sitesi Bağlantısı Başarılı. Status Code {StatusCode}", response.StatusCode);
            //    }
            //    else
            //    {
            //        _logger.LogInformation("Web Sitesi Bağlantısı Başarısız. Status Code {StatusCode}", response.StatusCode);
            //    }

            //    response.EnsureSuccessStatusCode();
            //    var content = await response.Content.ReadAsStringAsync();
            //    var document = XDocument.Parse(content);
            //    List<Exchange> exchange = await _secondExchangeRepository.GetAllAsync();

            //    if (exchange.Count > 0)
            //    {
            //        _logger.LogInformation($"2.Database de Toplam {exchange.Count} Adet Döviz Cinsi Bulundu");
            //        foreach (var item in exchange)
            //        {
            //            _logger.LogInformation($"Doviz Cinsi: {item.DovizId}");
            //        }
            //    }
            //    else
            //    {
            //        _logger.LogInformation("2.Databese Döviz Tablosunda Kayıt Yok");
            //    }

            //    foreach (var currency in exchange)
            //    {

            //        var countExchangeRateByDate = await _secondExchangeRateRepository.GetAllAsync(p => p.Tarih == date && p.DovizId == currency.DovizId);


            //        if (countExchangeRateByDate.Count() > 0)
            //        {
            //            switch (currency.DovizId)
            //            {
            //                case "TL":
            //                    break;
            //                case "EURO":
            //                    currencyCode = "EUR";
            //                    await UpdateAsync(currencyCode, document);
            //                    break;
            //                default:
            //                    await UpdateAsync(currency.DovizId, document);
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            switch (currency.DovizId)
            //            {
            //                case "TL":
            //                    await AddAsync(currency.DovizId, document);
            //                    break;
            //                case "EURO":
            //                    currencyCode = "EUR";
            //                    await AddAsync(currencyCode, document);
            //                    break;
            //                default:
            //                    await AddAsync(currency.DovizId, document);
            //                    break;
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{

            //    _logger.LogError(ex.Message);
            //}

        }

        public async Task AddAsync(string currency, XDocument document)
        {

            //if (currency is "TL")
            //{

            //    await _secondExchangeRateRepository.AddAsync(new ExchangeRate()
            //    {
            //        DovizId = currency,
            //        Tarih = DateTime.Now.Date,
            //        AlisFiati = 1,
            //        SatisFiati = 1,
            //        EfektifAlisFiati = 1,
            //        EfektifSatisFiati = 1,
            //        SerbestAlisFiati = 0,
            //        SerbestSatisFiati = 0,
            //        DegisimTarihi = DateTime.Now,
            //        InsertTarihi = DateTime.Now,
            //        InsertKullaniciId = 1,
            //        KullaniciId = 1
            //    });
            //}
            //else
            //{

            //    var node = document.Descendants("Currency").FirstOrDefault(x => x.Attribute("CurrencyCode").Value == currency);
            //    forexBuying = decimal.Parse(node.Element("ForexBuying").Value.Replace(".", ","));
            //    forexSelling = decimal.Parse(node.Element("ForexSelling").Value.Replace(".", ","));
            //    var banknoteBuyingControl = node.Element("BanknoteBuying").Value;
            //    banknoteBuying = banknoteBuyingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteBuying").Value.Replace(".", ","));
            //    var banknoteSellingControl = node.Element("BanknoteSelling").Value;
            //    banknoteSelling = banknoteSellingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteSelling").Value.Replace(".", ","));

            //    currencyCode = currency is "EUR" ? "EURO" : currency;

            //    await _secondExchangeRateRepository.AddAsync(new ExchangeRate()
            //    {
            //        DovizId = currencyCode,
            //        Tarih = DateTime.Now.Date,
            //        AlisFiati = forexBuying,
            //        SatisFiati = forexSelling,
            //        EfektifAlisFiati = banknoteBuying,
            //        EfektifSatisFiati = banknoteSelling,
            //        SerbestAlisFiati = 0,
            //        SerbestSatisFiati = 0,
            //        DegisimTarihi = DateTime.Now,
            //        InsertTarihi = DateTime.Now,
            //        InsertKullaniciId = 1,
            //        KullaniciId = 1
            //    });

            //    _logger.LogInformation($"2.Database {currencyCode} Kuru Eklendi. Alış Fiyatı: {forexBuying} , Satış Fiyatı: {forexSelling}");

            //}
        }

        public async Task UpdateAsync(string currency, XDocument document)
        {
            //currencyCode = currency is "EUR" ? "EURO" : currency;


            //_logger.LogInformation($"2.Databese {currencyCode} Döviz Kontrolü Yapılıyor.");

            //ExchangeRate exchangeRate = await _secondExchangeRateRepository.GetAsync(p => p.Tarih == date && p.DovizId == currencyCode);
            //var node = document.Descendants("Currency").FirstOrDefault(x => x.Attribute("CurrencyCode").Value == currency);
            //forexBuying = decimal.Parse(node.Element("ForexBuying").Value.Replace(".", ","));
            //forexSelling = decimal.Parse(node.Element("ForexSelling").Value.Replace(".", ","));
            //var banknoteBuyingControl = node.Element("BanknoteBuying").Value;
            //banknoteBuying = banknoteBuyingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteBuying").Value.Replace(".", ","));
            //var banknoteSellingControl = node.Element("BanknoteSelling").Value;
            //banknoteSelling = banknoteSellingControl is "" ? 0 : decimal.Parse(node.Element("BanknoteSelling").Value.Replace(".", ","));

            //if (exchangeRate is null)
            //{
            //    _logger.LogInformation($"2.Database {currencyCode} Kuruna Ait Kayıt Yok");
            //}
            //else
            //{
            //    if (exchangeRate.AlisFiati != forexBuying || exchangeRate.SatisFiati != forexSelling)
            //    {
            //        _logger.LogInformation($"2.Database {currencyCode} Kurunda Farklılık Var. Sistemde Olan Kur Alış Fiyatı: {exchangeRate.AlisFiati} - Gerçek Alış Kur Fiyatı: {forexBuying} / Sistemde Olan Kur Satış Fiyatı: {exchangeRate.SatisFiati} - Gerçek Satış Kur Fiyatı: {forexSelling}");

            //        await _secondExchangeRateRepository.DeleteAsync(exchangeRate);
            //        await _secondExchangeRateRepository.AddAsync(new ExchangeRate()
            //        {
            //            DovizId = exchangeRate.DovizId,
            //            Tarih = exchangeRate.Tarih,
            //            AlisFiati = forexBuying,
            //            SatisFiati = forexSelling,
            //            EfektifAlisFiati = exchangeRate.EfektifAlisFiati,
            //            EfektifSatisFiati = exchangeRate.EfektifSatisFiati,
            //            SerbestAlisFiati = exchangeRate.SerbestAlisFiati,
            //            SerbestSatisFiati = exchangeRate.SerbestSatisFiati,
            //            DegisimTarihi = DateTime.Now,
            //            InsertTarihi = DateTime.Now,
            //            InsertKullaniciId = 1,
            //            KullaniciId = 1
            //        });

            //        _logger.LogInformation($"2.Database {currencyCode} Kuru Düzeltildi");
            //    }
            //    else
            //    {
            //        _logger.LogInformation($"2.Database {currencyCode} Kur Fiyatında Farklılık Yok");
            //    }

            //}
        }
    }
}
