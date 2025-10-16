using SampleCoreBank.Core.Domain.CoreBank.Entities;
using Microsoft.EntityFrameworkCore;
using SampleCoreBank.Infrastructures.Data.CoreBank.EntityMappings;

namespace SampleCoreBank.Infrastructures.Data.CoreBank
{
    public class CoreBankDbContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<DesativacaoConta> DesativacaoContas { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected CoreBankDbContext()
        {
            Migrate();
        }
        public CoreBankDbContext(DbContextOptions<CoreBankDbContext> options) : base(options)
        {
            Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new DesativacaoContaMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());

            base.OnModelCreating(modelBuilder);
        }
        private void Migrate()
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
        }
    }
}