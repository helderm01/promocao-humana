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
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.DataRetirada)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(c => c.Familia)
                .WithMany()
                .HasForeignKey("FamiliaId");

            builder.Property(c => c.QuemRetirou)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired(); 

            builder.HasOne(c => c.LocalRetirada)
                .WithMany()
                .HasForeignKey("LocalRetiradaId"); 

            builder.Property(c => c.Tipo)
                .HasColumnType("long")
                .IsRequired(); 
        }
    }
}