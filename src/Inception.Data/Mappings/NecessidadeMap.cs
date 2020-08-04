using Inception.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inception.Data.Mappings
{
    public class NecessidadeMap : IEntityTypeConfiguration<Necessidade>
    {
        public void Configure(EntityTypeBuilder<Necessidade> builder)
        {
            builder.ToTable(nameof(Necessidade));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(p => p.Abreviacao).HasColumnType("VARCHAR(10)").IsRequired();
        }
    }
}
