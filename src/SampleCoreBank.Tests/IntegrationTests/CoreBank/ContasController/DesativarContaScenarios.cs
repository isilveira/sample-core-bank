using Newtonsoft.Json;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Tests.Helpers;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreBank.Tests.IntegrationTests.CoreBank.ContasController
{
	[TestClass]
	public class DesativarContaScenarios
	{
		[TestMethod]
		public async Task POST_DesativarConta_Return_Ok()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new DesativacaoConta()
			{
				Responsavel = "Maria Silva"
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/12345678901/desativar", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_DesativarConta_DocumentoTitular_Invalido_Return_BadRequest()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new DesativacaoConta()
			{
				Responsavel = "Maria Silva"
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/00000000001/desativar", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_DesativarConta_Faltando_Responsavel_Return_BadRequest()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new DesativacaoConta()
			{
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas/12345678901/desativar", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
	}
}
