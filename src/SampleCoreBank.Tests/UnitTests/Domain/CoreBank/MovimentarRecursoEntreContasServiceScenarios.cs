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
	public class MovimentarRecursoEntreContasServiceScenarios
	{
		[TestMethod]
		public async Task MovimentarRecursoEntreContasService_Return_Ok()
		{

			var contextData = MovimentacoesCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData().SetupMovimentacoesData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoEntreContasServiceRequestHandler>();

				var validador = new MovimentacaoValidator();

				var specificationContaDebitadaEhValida = new MovimetacaoContaDebitadaEhValidaSpecification(reader);
				var specificationContaDebitadaEhAtiva = new MovimetacaoContaDebitadaEhAtivaSpecification(reader);
				var specificationContaCreditadaEhValida = new MovimetacaoContaCreditadaEhValidaSpecification(reader);
				var specificationContaCreditadaEhAtiva = new MovimetacaoContaCreditadaEhAtivaSpecification(reader);
				var specificationSaldoDebitada = new MovimetacaoVerificaSaldoContaDebitadaSpecification(reader);

				var specificationsValidator = new MovimentarRecursoEntreContasSpecificationsValidator(
					specificationContaDebitadaEhValida, specificationContaDebitadaEhAtiva,
					specificationContaCreditadaEhValida, specificationContaCreditadaEhAtiva,
					specificationSaldoDebitada);

				var handler = new MovimentarRecursoEntreContasServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new MovimentarRecursoEntreContasServiceRequest(
					new Movimentacao() {
						DocumentoTitularDebitado = "12345678901",
						DocumentoTitularCreditado = "10987654321",
						Valor = 100,
					}
				);

				var result = await handler.Handle(request, default);

				Assert.IsNotNull(result);
			}
		}
		[TestMethod]
		public async Task MovimentarRecursoEntreContasService_DocumentoDebitado_Invalido_Return_Ok()
		{

			var contextData = MovimentacoesCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData().SetupMovimentacoesData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoEntreContasServiceRequestHandler>();

				var validador = new MovimentacaoValidator();

				var specificationContaDebitadaEhValida = new MovimetacaoContaDebitadaEhValidaSpecification(reader);
				var specificationContaDebitadaEhAtiva = new MovimetacaoContaDebitadaEhAtivaSpecification(reader);
				var specificationContaCreditadaEhValida = new MovimetacaoContaCreditadaEhValidaSpecification(reader);
				var specificationContaCreditadaEhAtiva = new MovimetacaoContaCreditadaEhAtivaSpecification(reader);
				var specificationSaldoDebitada = new MovimetacaoVerificaSaldoContaDebitadaSpecification(reader);

				var specificationsValidator = new MovimentarRecursoEntreContasSpecificationsValidator(
					specificationContaDebitadaEhValida, specificationContaDebitadaEhAtiva,
					specificationContaCreditadaEhValida, specificationContaCreditadaEhAtiva,
					specificationSaldoDebitada);

				var handler = new MovimentarRecursoEntreContasServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new MovimentarRecursoEntreContasServiceRequest(
					new Movimentacao()
					{
						DocumentoTitularDebitado = "00000000001",
						DocumentoTitularCreditado = "10987654321",
						Valor = 100,
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
		[TestMethod]
		public async Task MovimentarRecursoEntreContasService_DocumentoDebitado_Inativo_Return_Ok()
		{

			var contextData = MovimentacoesCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData().SetupMovimentacoesData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoEntreContasServiceRequestHandler>();

				var validador = new MovimentacaoValidator();

				var specificationContaDebitadaEhValida = new MovimetacaoContaDebitadaEhValidaSpecification(reader);
				var specificationContaDebitadaEhAtiva = new MovimetacaoContaDebitadaEhAtivaSpecification(reader);
				var specificationContaCreditadaEhValida = new MovimetacaoContaCreditadaEhValidaSpecification(reader);
				var specificationContaCreditadaEhAtiva = new MovimetacaoContaCreditadaEhAtivaSpecification(reader);
				var specificationSaldoDebitada = new MovimetacaoVerificaSaldoContaDebitadaSpecification(reader);

				var specificationsValidator = new MovimentarRecursoEntreContasSpecificationsValidator(
					specificationContaDebitadaEhValida, specificationContaDebitadaEhAtiva,
					specificationContaCreditadaEhValida, specificationContaCreditadaEhAtiva,
					specificationSaldoDebitada);

				var handler = new MovimentarRecursoEntreContasServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new MovimentarRecursoEntreContasServiceRequest(
					new Movimentacao()
					{
						DocumentoTitularDebitado = "11223344556",
						DocumentoTitularCreditado = "10987654321",
						Valor = 100,
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
		[TestMethod]
		public async Task MovimentarRecursoEntreContasService_DocumentoCreditado_Invalido_Return_Ok()
		{

			var contextData = MovimentacoesCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData().SetupMovimentacoesData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoEntreContasServiceRequestHandler>();

				var validador = new MovimentacaoValidator();

				var specificationContaDebitadaEhValida = new MovimetacaoContaDebitadaEhValidaSpecification(reader);
				var specificationContaDebitadaEhAtiva = new MovimetacaoContaDebitadaEhAtivaSpecification(reader);
				var specificationContaCreditadaEhValida = new MovimetacaoContaCreditadaEhValidaSpecification(reader);
				var specificationContaCreditadaEhAtiva = new MovimetacaoContaCreditadaEhAtivaSpecification(reader);
				var specificationSaldoDebitada = new MovimetacaoVerificaSaldoContaDebitadaSpecification(reader);

				var specificationsValidator = new MovimentarRecursoEntreContasSpecificationsValidator(
					specificationContaDebitadaEhValida, specificationContaDebitadaEhAtiva,
					specificationContaCreditadaEhValida, specificationContaCreditadaEhAtiva,
					specificationSaldoDebitada);

				var handler = new MovimentarRecursoEntreContasServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new MovimentarRecursoEntreContasServiceRequest(
					new Movimentacao()
					{
						DocumentoTitularDebitado = "12345678901",
						DocumentoTitularCreditado = "00000000001",
						Valor = 100,
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
		[TestMethod]
		public async Task MovimentarRecursoEntreContasService_DocumentoCreditado_Inativo_Return_Ok()
		{

			var contextData = MovimentacoesCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData().SetupMovimentacoesData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoEntreContasServiceRequestHandler>();

				var validador = new MovimentacaoValidator();

				var specificationContaDebitadaEhValida = new MovimetacaoContaDebitadaEhValidaSpecification(reader);
				var specificationContaDebitadaEhAtiva = new MovimetacaoContaDebitadaEhAtivaSpecification(reader);
				var specificationContaCreditadaEhValida = new MovimetacaoContaCreditadaEhValidaSpecification(reader);
				var specificationContaCreditadaEhAtiva = new MovimetacaoContaCreditadaEhAtivaSpecification(reader);
				var specificationSaldoDebitada = new MovimetacaoVerificaSaldoContaDebitadaSpecification(reader);

				var specificationsValidator = new MovimentarRecursoEntreContasSpecificationsValidator(
					specificationContaDebitadaEhValida, specificationContaDebitadaEhAtiva,
					specificationContaCreditadaEhValida, specificationContaCreditadaEhAtiva,
					specificationSaldoDebitada);

				var handler = new MovimentarRecursoEntreContasServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new MovimentarRecursoEntreContasServiceRequest(
					new Movimentacao()
					{
						DocumentoTitularDebitado = "12345678901",
						DocumentoTitularCreditado = "11223344556",
						Valor = 100,
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
		[TestMethod]
		public async Task MovimentarRecursoEntreContasService_Saldo_Insuficiente_Return_Ok()
		{

			var contextData = MovimentacoesCollections.GetDefaultCollection();

			using (var context = CoreBankDbContextExtensions.GetInMemoryCoreBankDbContext().SetupContasData().SetupDesativacaoContasData().SetupMovimentacoesData(contextData))
			{
				var reader = new CoreBankDbContextReader(context);
				var writer = new CoreBankDbContextWriter(context);

				var mockedLogger = new Mock<ILoggerFactory>();

				var localizer = GenericHelper.CreateLocalizer<MovimentarRecursoEntreContasServiceRequestHandler>();

				var validador = new MovimentacaoValidator();

				var specificationContaDebitadaEhValida = new MovimetacaoContaDebitadaEhValidaSpecification(reader);
				var specificationContaDebitadaEhAtiva = new MovimetacaoContaDebitadaEhAtivaSpecification(reader);
				var specificationContaCreditadaEhValida = new MovimetacaoContaCreditadaEhValidaSpecification(reader);
				var specificationContaCreditadaEhAtiva = new MovimetacaoContaCreditadaEhAtivaSpecification(reader);
				var specificationSaldoDebitada = new MovimetacaoVerificaSaldoContaDebitadaSpecification(reader);

				var specificationsValidator = new MovimentarRecursoEntreContasSpecificationsValidator(
					specificationContaDebitadaEhValida, specificationContaDebitadaEhAtiva,
					specificationContaCreditadaEhValida, specificationContaCreditadaEhAtiva,
					specificationSaldoDebitada);

				var handler = new MovimentarRecursoEntreContasServiceRequestHandler(
					writer,
					localizer,
					validador,
					specificationsValidator);

				var request = new MovimentarRecursoEntreContasServiceRequest(
					new Movimentacao()
					{
						DocumentoTitularDebitado = "12345678901",
						DocumentoTitularCreditado = "10987654321",
						Valor = 10000,
					}
				);

				await Assert.ThrowsExceptionAsync<BusinessException>(async () => await handler.Handle(request, default));
			}
		}
	}
}
