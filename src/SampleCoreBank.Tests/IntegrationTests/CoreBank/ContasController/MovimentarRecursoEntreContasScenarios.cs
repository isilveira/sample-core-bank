using Newtonsoft.Json;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Tests.Helpers;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;
using System.Net;
using System.Text;

namespace SampleCoreBank.Tests.IntegrationTests.CoreBank.ContasController
{
	[TestClass]
	public class MovimentarRecursoEntreContasScenarios
	{
		[TestMethod]
		public async Task POST_MovimentarRecursoEntreContas_Return_Ok()
		{
			var contas = ContasCollections.GetDefaultCollection();
			var desativacaoContas = DesativacaoContasCollections.GetDefaultCollection();
			var movimentacoes = MovimentacoesCollections.GetDefaultCollection();

			var data = new Movimentacao()
			{
				DocumentoTitularCreditado = "10987654321",
				Valor = 10M
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contas).SetupData<CoreBankDbContext, DesativacaoConta>(desativacaoContas).SetupData<CoreBankDbContext, Movimentacao>(movimentacoes).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/12345678901/transferir-recurso", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_MovimentarRecursoEntreContas_DocumentoTitularDebitado_Invalido_Return_BadRequest()
		{
			var contas = ContasCollections.GetDefaultCollection();
			var desativacaoContas = DesativacaoContasCollections.GetDefaultCollection();
			var movimentacoes = MovimentacoesCollections.GetDefaultCollection();

			var data = new Movimentacao()
			{
				DocumentoTitularCreditado = "10987654321",
				Valor = 10M
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contas).SetupData<CoreBankDbContext, DesativacaoConta>(desativacaoContas).SetupData<CoreBankDbContext, Movimentacao>(movimentacoes).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/00000000001/transferir-recurso", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_MovimentarRecursoEntreContas_DocumentoTitularDebitado_Inativo_Return_BadRequest()
		{
			var contas = ContasCollections.GetDefaultCollection();
			var desativacaoContas = DesativacaoContasCollections.GetDefaultCollection();
			var movimentacoes = MovimentacoesCollections.GetDefaultCollection();

			var data = new Movimentacao()
			{
				DocumentoTitularCreditado = "10987654321",
				Valor = 10M
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contas).SetupData<CoreBankDbContext, DesativacaoConta>(desativacaoContas).SetupData<CoreBankDbContext, Movimentacao>(movimentacoes).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/11223344556/transferir-recurso", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_MovimentarRecursoEntreContas_DocumentoTitularCreditado_Invalido_Return_BadRequest()
		{
			var contas = ContasCollections.GetDefaultCollection();
			var desativacaoContas = DesativacaoContasCollections.GetDefaultCollection();
			var movimentacoes = MovimentacoesCollections.GetDefaultCollection();

			var data = new Movimentacao()
			{
				DocumentoTitularCreditado = "00000000001",
				Valor = 10M
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contas).SetupData<CoreBankDbContext, DesativacaoConta>(desativacaoContas).SetupData<CoreBankDbContext, Movimentacao>(movimentacoes).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/10987654321/transferir-recurso", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_MovimentarRecursoEntreContas_DocumentoTitularCreditado_Inativo_Return_BadRequest()
		{
			var contas = ContasCollections.GetDefaultCollection();
			var desativacaoContas = DesativacaoContasCollections.GetDefaultCollection();
			var movimentacoes = MovimentacoesCollections.GetDefaultCollection();

			var data = new Movimentacao()
			{
				DocumentoTitularCreditado = "11223344556",
				Valor = 10M
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contas).SetupData<CoreBankDbContext, DesativacaoConta>(desativacaoContas).SetupData<CoreBankDbContext, Movimentacao>(movimentacoes).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/10987654321/transferir-recurso", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_MovimentarRecursoEntreContas_Saldo_DocumentoTitularDebitado_Insuficiente_Return_BadRequest()
		{
			var contas = ContasCollections.GetDefaultCollection();
			var desativacaoContas = DesativacaoContasCollections.GetDefaultCollection();
			var movimentacoes = MovimentacoesCollections.GetDefaultCollection();

			var data = new Movimentacao()
			{
				DocumentoTitularCreditado = "10987654321",
				Valor = 10000M
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contas).SetupData<CoreBankDbContext, DesativacaoConta>(desativacaoContas).SetupData<CoreBankDbContext, Movimentacao>(movimentacoes).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/12345678901/transferir-recurso", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
	}
}
