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
                .HasColumnType("nvarchar(8)")
                .IsRequired();

            builder.Property(c => c.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(c => c.Bairro)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(c => c.Cidade)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(c => c.Uf)
                .HasColumnType("nchar(2)")
                .IsRequired();

            builder.Property(c => c.Numero)
                .HasColumnType("varchar(5)");

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(50)");
        }
    }
}