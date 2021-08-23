using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromocaoHumana.Web.Domain;
using PromocaoHumana.Web.Domain.Structs;

namespace PromocaoHumana.Web.Data.Map
{
    public class FamiliaMap : IEntityTypeConfiguration<Familia>
    {
        public void Configure(EntityTypeBuilder<Familia> builder)
        {
            builder.ToTable(nameof(Familia));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Ativa)
                .IsRequired();

            builder.Property(c => c.CpfResponsavel)
                .HasConversion(new ValueConverter<Cpf, string>(c => c, value => new Cpf(value)))
                .HasMaxLength(15);

            builder.Property(c => c.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithMany()
                .HasForeignKey("EnderecoId");

            builder.Property(c => c.NomeConjuge)
                .HasMaxLength(150);

            builder.Property(c => c.NomeResponsavel)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(c => c.Paroquia)
                .WithMany()
                .HasForeignKey("ParoquiaId");

            builder.Property(c => c.QuantidadeFilhos)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}