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
public class DesativarContaCommandScenarios
{
    [TestMethod]
    public async Task DesativarContaCommand_Return_Ok()
    {

		var contextData = DesativacaoContasCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupDesativacaoContasData(contextData))
		{
			var writer = new CoreBankDbContextWriter(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<DesativarContaCommandHandler>();

			var handler = new DesativarContaCommandHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				writer);

			var command = new DesativarContaCommand();

			command.DocumentoTitular = "12345678901";

			var result = await handler.Handle(command, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}
}
