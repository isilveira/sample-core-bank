using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Tests.Helpers;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;
using System.Net;

namespace SampleCoreBank.Tests.IntegrationTests.CoreBank.ContasController
{
	[TestClass]
	public class BuscarMovimentacoesDaContaScenarios
	{

		[TestMethod]
		public async Task GET_BuscarMovimentacoesDaConta_Return_Ok()
		{
			var contextContasData = ContasCollections.GetDefaultCollection();
			var contextDesativacaoContasData = DesativacaoContasCollections.GetDefaultCollection();
			var contextMovimentacoesData = MovimentacoesCollections.GetDefaultCollection();

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextContasData).SetupData<CoreBankDbContext, DesativacaoConta>(contextDesativacaoContasData).SetupData<CoreBankDbContext, Movimentacao>(contextMovimentacoesData).CreateClient())
			{
				var response = await client.GetAsync($"/api/contas/12345678901/movimentacoes");

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			}
		}


		[TestMethod]
		public async Task GET_BuscarMovimentacoesDaConta_DocumentoTitular_Invalido_Return_NotFound()
		{
			var contextContasData = ContasCollections.GetDefaultCollection();
			var contextDesativacaoContasData = DesativacaoContasCollections.GetDefaultCollection();
			var contextMovimentacoesData = MovimentacoesCollections.GetDefaultCollection();

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextContasData).SetupData<CoreBankDbContext, DesativacaoConta>(contextDesativacaoContasData).SetupData<CoreBankDbContext, Movimentacao>(contextMovimentacoesData).CreateClient())
			{
				var response = await client.GetAsync($"/api/contas/00000000001/movimentacoes");

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
			}
		}
	}
}
