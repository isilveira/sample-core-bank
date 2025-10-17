using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Tests.Helpers;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;
using System.Net;

namespace SampleCoreBank.Tests.IntegrationTests.CoreBank.ContasController
{
	[TestClass]
	public class BuscarContasScenarios
	{
		[TestMethod]
		public async Task GET_BuscarContas_Return_Ok()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var response = await client.GetAsync($"/api/contas");

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			}
		}

		[TestMethod]
		public async Task GET_BuscarContas_Filtrando_DocumentoTitular_Return_Ok()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var response = await client.GetAsync($"/api/contas?DocumentoTitular=12345678901");

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.IsTrue(contentResponse.Contains("12345678901"));
			}
		}

		[TestMethod]
		public async Task GET_BuscarContas_Filtrando_NomeTitular_Return_Ok()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var response = await client.GetAsync($"/api/contas?NomeTitular=João");

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.IsTrue(contentResponse.Contains("12345678901"));
			}
		}
	}
}
