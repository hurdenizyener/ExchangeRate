using Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class ExchangeRateKnitConfiguration : IEntityTypeConfiguration<ExchangeRateKnit>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateKnit> builder)
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
                .HasOne(p => p.Exchange)
                .WithMany()
              //  .WithMany(a => a.ExchangeRateKnits)
                .HasForeignKey(p => p.DovizId);

        }
    }
}
