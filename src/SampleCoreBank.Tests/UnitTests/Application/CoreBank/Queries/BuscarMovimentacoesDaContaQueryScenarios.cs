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
public class BuscarMovimentacoesDaContaQueryScenarios
{
    [TestMethod]
    public async Task BuscarMovimentacoesDaContaQuery_Return_Ok()
    {

		var contextData = MovimentacoesCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupMovimentacoesData())
		{
			var reader = new CoreBankDbContextReader(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<BuscarMovimentacoesDaContaQueryHandler>();

			var handler = new BuscarMovimentacoesDaContaQueryHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				reader);

			var query = new BuscarMovimentacoesDaContaQuery();

			query.DocumentoTitular = "12345678900";

			var result = await handler.Handle(query, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}
}
