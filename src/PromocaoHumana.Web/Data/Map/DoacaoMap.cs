using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromocaoHumana.Web.Domain;

namespace PromocaoHumana.Web.Data.Map
{
    public class DoacaoMap : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {
            builder.ToTable(nameof(Doacao));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.DataRetirada)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.MesRetirada)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(c => c.QuemRetirou)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(c => c.Familia)
                .WithMany(c=>c.Doacoes)
                .HasForeignKey(c => c.FamiliaId)
                .IsRequired();

            builder.HasOne(c => c.LocalRetirada)
                .WithMany(c=>c.Doacoes)
                .HasForeignKey(c => c.LocalRetiradaId)
                .IsRequired();

            builder.HasIndex(c => new { c.MesRetirada, c.FamiliaId })
                .IsUnique();
        }
    }
}