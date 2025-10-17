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
	public class DesativarContaServiceScenarios
	{
		[TestMethod]
		public async Task DesativarContaService_Return_Ok()
		{

			var contextData = DesativacaoContasCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<DesativarContaServiceRequestHandler>();

				var validador = new DesativacaoContaValidator();

				var specification = new ContaExisteSpecification(reader);

				var specificationsValidator = new DesativarContaSpecificationsValidator(specification);

				var handler = new DesativarContaServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new DesativarContaServiceRequest(
					new DesativacaoConta() {
						DocumentoTitular = "12345678901",
						Responsavel = "Teste Unitario",
					}
				);

				var result = await handler.Handle(request, default);

				Assert.IsNotNull(result);
			}
		}
		[TestMethod]
		public async Task DesativarContaService_Responsavel_Vazio_Return_BusinessException()
		{

			var contextData = DesativacaoContasCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupDesativacaoContasData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<DesativarContaServiceRequestHandler>();

				var validador = new DesativacaoContaValidator();

				var specification = new ContaExisteSpecification(reader);

				var specificationsValidator = new DesativarContaSpecificationsValidator(specification);

				var handler = new DesativarContaServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new DesativarContaServiceRequest(
					new DesativacaoConta()
					{
						DocumentoTitular = "12345678901",
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
		[TestMethod]
		public async Task DesativarContaService_DocumentoTitular_Invalido_Return_BusinessException()
		{

			var contextData = DesativacaoContasCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupDesativacaoContasData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<DesativarContaServiceRequestHandler>();

				var validador = new DesativacaoContaValidator();

				var specification = new ContaExisteSpecification(reader);

				var specificationsValidator = new DesativarContaSpecificationsValidator(specification);

				var handler = new DesativarContaServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new DesativarContaServiceRequest(
					new DesativacaoConta()
					{
						DocumentoTitular = "00000000001",
						Responsavel = "Teste Unitario",
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
	}
}
