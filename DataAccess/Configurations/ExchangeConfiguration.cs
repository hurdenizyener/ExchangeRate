using Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configurations
{
    public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> builder)
        {
            builder
                .ToTable("DOVIZ")
                .HasKey(p => p.DovizId);

            builder
                .Property(p => p.DovizId)
                .HasColumnName("DOVIZID");

        }
    }
}
