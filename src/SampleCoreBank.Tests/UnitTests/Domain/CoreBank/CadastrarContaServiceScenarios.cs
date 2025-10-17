using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SampleCoreBank.Core.Application.Commands;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Services;
using SampleCoreBank.Core.Domain.CoreBank.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations;
using SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations;
using SampleCoreBank.Infrastructures.Data.CoreBank;
using SampleCoreBank.Shared.Abstractions.Domain.Exceptions;
using SampleCoreBank.Tests.Helpers;
using SampleCoreBank.Tests.Helpers.Data.CoreBank;
using SampleCoreBank.Tests.Helpers.Data.CoreBank.DataCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreBank.Tests.UnitTests.Domain.CoreBank
{
	[TestClass]
	public class CadastrarContaServiceScenarios
	{
		[TestMethod]
		public async Task CadastrarContaService_Return_Ok()
		{

			var contextData = ContasCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<CadastrarContaServiceRequestHandler>();

				var validador = new ContaValidator();

				var specification = new NaoPermitirCadastrarContaComMesmoDocumentoSpecification(reader);

				var specificationsValidator = new CadastrarContaSpecificationsValidator(specification);

				var handler = new CadastrarContaServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new CadastrarContaServiceRequest(
					new Conta() {
						DocumentoTitular = "00000000001",
						NomeTitular = "Teste Titular 001",
					}
				);

				var result = await handler.Handle(request, default);

				Assert.IsNotNull(result);
			}
		}
		[TestMethod]
		public async Task CadastrarContaService_DocumentoTitular_Duplicado_Return_BusinessException()
		{

			var contextData = ContasCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<CadastrarContaServiceRequestHandler>();

				var validador = new ContaValidator();

				var specification = new NaoPermitirCadastrarContaComMesmoDocumentoSpecification(reader);

				var specificationsValidator = new CadastrarContaSpecificationsValidator(specification);

				var handler = new CadastrarContaServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new CadastrarContaServiceRequest(
					new Conta()
					{
						DocumentoTitular = "12345678901",
						NomeTitular = "Teste Titular 001",
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
	}
}
