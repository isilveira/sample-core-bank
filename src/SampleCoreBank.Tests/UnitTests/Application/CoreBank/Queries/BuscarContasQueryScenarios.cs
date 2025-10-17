using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SampleCoreBank.Core.Application.Commands;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Tests.Helpers;
using SampleCoreBank.Tests.Helpers.Data.CoreBank;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;
using System.Net;

namespace SampleCoreBank.Tests;

[TestClass]
public class BuscarContasQueryScenarios
{
    [TestMethod]
    public async Task BuscarContasQuery_Return_Ok()
    {

		var contextData = ContasCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData(contextData).SetupDesativacaoContasData())
		{
			var reader = new CoreBankDbContextReader(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<BuscarContasQueryHandler>();

			var handler = new BuscarContasQueryHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				reader);

			var query = new BuscarContasQuery();

			var result = await handler.Handle(query, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}

	[TestMethod]
	public async Task BuscarContasQuery_Filrando_DocumentoTitular_Return_Ok()
	{

		var contextData = ContasCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData(contextData).SetupDesativacaoContasData())
		{
			var reader = new CoreBankDbContextReader(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<BuscarContasQueryHandler>();

			var handler = new BuscarContasQueryHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				reader);

			var query = new BuscarContasQuery();

			query.DocumentoTitular = "12345678900";

			var result = await handler.Handle(query, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}

	[TestMethod]
	public async Task BuscarContasQuery_Filrando_NomeTitular_Return_Ok()
	{

		var contextData = ContasCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData(contextData).SetupDesativacaoContasData())
		{
			var reader = new CoreBankDbContextReader(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<BuscarContasQueryHandler>();

			var handler = new BuscarContasQueryHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				reader);

			var query = new BuscarContasQuery();

			query.NomeTitular = "Silva";

			var result = await handler.Handle(query, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}
}
