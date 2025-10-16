using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleCoreBank.Core.Domain.CoreBank.Entities;

namespace SampleCoreBank.Infrastructures.Data.CoreBank.EntityMappings
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder
                .Property<string>(p => p.DocumentoTitularDebitado)
                .HasColumnName("DocumentoTitularDebitado")
                .HasColumnType("NVARCHAR(11)")
                .IsRequired(true);

            builder
                .Property<string>(p => p.DocumentoTitularCreditado)
                .HasColumnName("DocumentoTitularCreditado")
                .HasColumnType("NVARCHAR(11)")
                .IsRequired(true);

            builder
                .Property<decimal>(p => p.Valor)
                .HasColumnName("Valor")
                .HasColumnType("DECIMAL(18,2)")
                .IsRequired(true);
                
            builder
                .Property<DateTime>(p => p.DataOperacao)
                .HasColumnName("DataOperacao")
                .HasColumnType("DATETIME")
                .IsRequired(true);

            builder.HasKey(p => new { p.DocumentoTitularDebitado, p.DocumentoTitularCreditado, p.Valor, p.DataOperacao });

            builder.ToTable("Movimentacoes");
        }
    }
}