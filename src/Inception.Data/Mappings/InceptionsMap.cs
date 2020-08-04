using Inception.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inception.Data.Mappings
{
    public class InceptionsMap : IEntityTypeConfiguration<Inceptions>
    {
        public void Configure(EntityTypeBuilder<Inceptions> builder)
        {
            builder.ToTable(nameof(Inceptions));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(p => p.Identificador).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnType("DATETIME2(7)").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("DATETIME2(7)");
            builder.HasMany(p => p.Problemas).WithOne(x => x.Inceptions).HasForeignKey(x => x.IdInceptions);
            builder.HasMany(p => p.Necessidades).WithOne(x => x.Inceptions).HasForeignKey(x => x.IdInceptions);
        }
    }
}
