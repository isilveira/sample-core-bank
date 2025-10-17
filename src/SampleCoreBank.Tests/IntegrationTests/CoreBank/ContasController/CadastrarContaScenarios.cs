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
	public class CadastrarContaScenarios
	{
		[TestMethod]
		public async Task POST_CadastrarConta_Return_Ok()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new Conta()
			{
				DocumentoTitular = "09876543210",
				NomeTitular = "Maria Silva"
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_CadastrarConta_Faltando_DocumentoTitular_Return_BadRequest()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new Conta()
			{
				NomeTitular = "Maria Silva"
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_CadastrarConta_Faltando_NomeTitular_Return_BadRequest()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new Conta()
			{
				DocumentoTitular = "09876543210",
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
		[TestMethod]
		public async Task POST_CadastrarConta_DocumentoTitular_Duplicado_Return_BadRequest()
		{
			var contextData = ContasCollections.GetDefaultCollection();

			var data = new Conta()
			{
				DocumentoTitular = "12345678901",
				NomeTitular = "Maria Silva"
			};

			using (var client = ServerHelper.Create().SetupData<CoreBankDbContext, Conta>(contextData).CreateClient())
			{
				var json = JsonConvert.SerializeObject(data);
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var response = await client.PostAsync($"/api/contas", content);

				var contentResponse = await response.Content.ReadAsStringAsync();

				Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
			}
		}
	}
}
