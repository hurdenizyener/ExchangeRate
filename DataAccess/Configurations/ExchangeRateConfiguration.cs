using Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder
                .ToTable("DOVIZKURU")
                .HasKey(p => new { p.Tarih, p.DovizId });

            builder
                .Property(p => p.Tarih)
                .HasColumnName("TARIH");

            builder
                .Property(p => p.DovizId)
                .HasColumnName("DOVIZID");

            builder
                .Property(p => p.AlisFiati)
                .HasColumnName("ALISFIATI");

            builder
                .Property(p => p.SatisFiati)
                .HasColumnName("SATISFIATI");

            builder
                .Property(p => p.SerbestAlisFiati)
                .HasColumnName("SERBESTALISFIATI");

            builder
                .Property(p => p.SerbestSatisFiati)
                .HasColumnName("SERBESTSATISFIATI");

            builder
                .Property(p => p.EfektifAlisFiati)
                .HasColumnName("EFEKTIFALISFIATI");

            builder
                .Property(p => p.EfektifSatisFiati)
                .HasColumnName("EFEKTIFSATISFIATI");

            builder
                .Property(p => p.InsertKullaniciId)
                .HasColumnName("INSERTKULLANICIID");

            builder
                .Property(p => p.InsertTarihi)
                .HasColumnName("INSERTTARIHI");

            builder
                .Property(p => p.KullaniciId)
                .HasColumnName("KULLANICIID");

            builder
                .Property(p => p.DegisimTarihi)
                .HasColumnName("DEGISIMTARIHI");

            builder
                .HasOne(p => p.Exchange)
                .WithMany(a => a.ExchangeRates)
                .HasForeignKey(p => p.DovizId);

        }
    }
}
