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
public class CadastrarContaCommandScenarios
{
    [TestMethod]
    public async Task CadastrarContaCommand_Return_Ok()
    {

		var contextData = ContasCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData(contextData))
		{
			var writer = new CoreBankDbContextWriter(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<CadastrarContaCommandHandler>();

			var handler = new CadastrarContaCommandHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				writer);

			var command = new CadastrarContaCommand();

			command.DocumentoTitular = "00000000001";
			command.NomeTitular = "Teste Titular 001";

			var result = await handler.Handle(command, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}
}
