using System.Runtime.CompilerServices;
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

            builder.Property(c => c.NomeConjuge)
                .HasMaxLength(150);

            builder.Property(c => c.NomeResponsavel)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.QuantidadeFilhos)
                .IsRequired()
                .HasDefaultValue(0);
            
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
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Numero)
                .HasMaxLength(5);

            builder.Property(c => c.Complemento)
                .HasMaxLength(50);
            
            builder.Property(c=>c.Telefone)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Observacoes)
                .HasMaxLength(200);
            
            builder.HasIndex(c => c.CpfResponsavel)
                .IsUnique();
        }
    }
}