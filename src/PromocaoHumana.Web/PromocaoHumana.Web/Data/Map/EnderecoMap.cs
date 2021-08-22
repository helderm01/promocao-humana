using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromocaoHumana.Web.Domain;

namespace PromocaoHumana.Web.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable(nameof(Endereco));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Cep)
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(c => c.Logradouro)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Bairro)
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(c => c.Cidade)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Uf)
                .HasColumnType("nchar")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Numero)
                .HasColumnType("varchar")
                .HasMaxLength(5);

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar")
                .HasMaxLength(50);

        }
    }
}