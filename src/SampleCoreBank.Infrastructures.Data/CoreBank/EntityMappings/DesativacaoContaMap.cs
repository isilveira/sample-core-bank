using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleCoreBank.Core.Domain.CoreBank.Entities;

namespace SampleCoreBank.Infrastructures.Data.CoreBank.EntityMappings
{
    public class DesativacaoContaMap : IEntityTypeConfiguration<DesativacaoConta>
    {
        public void Configure(EntityTypeBuilder<DesativacaoConta> builder)
        {
            builder
                .Property<string>(p => p.DocumentoTitular)
                .HasColumnName("DocumentoTitular")
                .HasColumnType("NVARCHAR(11)")
                .IsRequired(true);

            builder
                .Property<DateTime>(p => p.Data)
                .HasColumnName("Data")
                .HasColumnType("DATETIME)")
                .IsRequired(true);
                
            builder
                .Property<string>(p => p.Responsavel)
                .HasColumnName("Responsavel")
                .HasColumnType("NVARCHAR(128)")
                .IsRequired(true);

            builder.HasKey(p => p.DocumentoTitular);

            builder.ToTable("DesativacaoContas");
        }
    }
}