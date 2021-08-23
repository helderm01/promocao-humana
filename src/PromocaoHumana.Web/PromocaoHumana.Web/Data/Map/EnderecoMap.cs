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
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(c => c.Logradouro)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Bairro)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(c => c.Cidade)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Uf)
                .HasColumnType("nchar")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Numero)
                .HasMaxLength(5);

            builder.Property(c => c.Complemento)
                .HasMaxLength(50);
        }
    }
}