using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleCoreBank.Core.Domain.CoreBank.Entities;

namespace SampleCoreBank.Infrastructures.Data.CoreBank.EntityMappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder
                .Property<string>(p => p.NomeTitular)
                .HasColumnName("NomeTitular")
                .HasColumnType("NVARCHAR(128)")
                .IsRequired(true);

            builder
                .Property<string>(p => p.DocumentoTitular)
                .HasColumnName("DocumentoTitular")
                .HasColumnType("NVARCHAR(11)")
                .IsRequired(true);

            builder
                .Property<decimal>(p => p.Saldo)
                .HasColumnName("Saldo")
                .HasColumnType("DECIMAL(18,2)")
                .IsRequired(true);

            builder
                .Property<DateTime>(p => p.DataAbertura)
                .HasColumnName("DataAbertura")
                .HasColumnType("DATETIME")
                .IsRequired(true);

            builder
                .Ignore(p => p.Status);

            builder.HasKey(p => p.DocumentoTitular);

            builder.ToTable("Contas");

            builder
                .HasOne(p => p.DesativacaoConta)
                .WithOne(p => p.Conta)
                .HasForeignKey<DesativacaoConta>(p => p.DocumentoTitular)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(p => p.MovimentacoesDebitadas)
                .WithOne(p => p.ContaDebitada)
                .HasForeignKey(p => p.DocumentoTitularDebitado)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(p => p.MovimentacoesCreditadas)
                .WithOne(p => p.ContaCreditada)
                .HasForeignKey(p => p.DocumentoTitularCreditado)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}