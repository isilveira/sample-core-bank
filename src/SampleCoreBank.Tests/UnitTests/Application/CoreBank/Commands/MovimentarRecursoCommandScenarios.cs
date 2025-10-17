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
public class MovimentarRecursoCommandScenarios
{
    [TestMethod]
    public async Task MovimentarRecursoCommand_Return_Ok()
    {

		var contextData = MovimentacoesCollections.GetDefaultCollection();

		using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupMovimentacoesData(contextData))
		{
			var writer = new CoreBankDbContextWriter(context);

			var mockedLogger = new Mock<ILoggerFactory>();

			var mockedMediator = new Mock<IMediator>();

			var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoCommandHandler>();

			var handler = new MovimentarRecursoCommandHandler(
				mockedLogger.Object,
				mockedMediator.Object,
				localizer,
				writer);

			var command = new MovimentarRecursoCommand();

			command.DocumentoTitularDebitado = "12345678901";
			command.DocumentoTitularCreditado = "10987654321";
			command.Valor = 15m;

			var result = await handler.Handle(command, default);

			Assert.AreEqual((long)HttpStatusCode.OK, result.StatusCode);
		}
	}
}
