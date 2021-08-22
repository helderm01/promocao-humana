using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromocaoHumana.Web.Domain;
using PromocaoHumana.Web.Domain.Structs;

namespace PromocaoHumana.Web.Data.Map
{
    public class IgrejaMap : IEntityTypeConfiguration<Igreja>
    {
        public void Configure(EntityTypeBuilder<Igreja> builder)
        {
            builder.ToTable(nameof(Igreja));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Paroco)
                .HasColumnType("varchar")
                .HasMaxLength(60);

            builder.HasOne(c => c.Endereco)
                .WithMany()
                .HasForeignKey("EnderecoId");

            builder.Property(c => c.Cnpj)
                .HasConversion(new ValueConverter<Cnpj, string>(c => c, value => new Cnpj(value)))
                .HasColumnType("nvarchar")
                .HasMaxLength(14);
        }
    }
}