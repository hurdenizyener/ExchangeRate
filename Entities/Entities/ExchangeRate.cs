using Entities.Common;

namespace Entities.Entities
{
    public class ExchangeRate : IEntity
    {
        public DateTime Tarih { get; set; } 
        public string DovizId { get; set; }
        public decimal AlisFiati { get; set; }
        public decimal SatisFiati { get; set; }
        public decimal SerbestAlisFiati { get; set; }
        public decimal SerbestSatisFiati { get; set; }
        public decimal EfektifAlisFiati { get; set; }
        public decimal EfektifSatisFiati { get; set; }
        public int InsertKullaniciId { get; set; }
        public DateTime InsertTarihi { get; set; }
        public int KullaniciId { get; set; }
        public DateTime DegisimTarihi { get; set; }

        public Exchange Exchange { get; set; }
    }
}
