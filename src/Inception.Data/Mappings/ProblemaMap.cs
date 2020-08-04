using Inception.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inception.Data.Mappings
{
    public class ProblemaMap : IEntityTypeConfiguration<Problema>
    {
        public void Configure(EntityTypeBuilder<Problema> builder)
        {
            builder.ToTable(nameof(Problema));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(p => p.Abreviacao).HasColumnType("VARCHAR(10)").IsRequired();
        }
    }
}
