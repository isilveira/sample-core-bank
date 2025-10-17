using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;

namespace SampleCoreBank.Tests.Helpers.Data.CoreBank
{
	public static class AddMockedCoreBankCollections
	{
		public static CoreBankDbContext SetupContasData(this CoreBankDbContext context, List<Conta> entities = null)
		{
			if (entities == null)
				context.Contas.AddRange(ContasCollections.GetDefaultCollection());
			else
				context.AddRange(entities);

			context.SaveChanges();

			return context;
		}
		public static CoreBankDbContext SetupDesativacaoContasData(this CoreBankDbContext context, List<DesativacaoConta> entities = null)
		{
			if (entities == null)
				context.DesativacaoContas.AddRange(DesativacaoContasCollections.GetDefaultCollection());
			else
				context.AddRange(entities);

			context.SaveChanges();

			return context;
		}
		public static CoreBankDbContext SetupMovimentacoesData(this CoreBankDbContext context, List<Movimentacao> entities = null)
		{
			if (entities == null)
				context.Movimentacoes.AddRange(MovimentacoesCollections.GetDefaultCollection());
			else
				context.AddRange(entities);
			
			context.SaveChanges();

			return context;
		}
	}
}
