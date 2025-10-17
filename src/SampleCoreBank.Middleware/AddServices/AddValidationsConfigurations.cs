using Microsoft.Extensions.DependencyInjection;
using SampleCoreBank.Core.Domain.CoreBank.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations;
using SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreBank.Middleware.AddServices
{
	public static class AddValidationsConfigurations
	{
		public static IServiceCollection AddSpecifications(this IServiceCollection services)
		{
			services.AddTransient<ContaExisteSpecification>();
			services.AddTransient<MovimetacaoContaCreditadaEhValidaSpecification>();
			services.AddTransient<MovimetacaoContaDebitadaEhValidaSpecification>();
			services.AddTransient<MovimetacaoVerificaSaldoContaDebitadaSpecification>();
			services.AddTransient<NaoPermitirCadastrarContaComMesmoDocumentoSpecification>();

			return services;
		}
		public static IServiceCollection AddEntityValidations(this IServiceCollection services)
		{
			services.AddTransient<ContaValidator>();
			services.AddTransient<DesativacaoContaValidator>();
			services.AddTransient<MovimentacaoValidator>();

			return services;
		}
		public static IServiceCollection AddDomainValidations(this IServiceCollection services)
		{
			services.AddTransient<CadastrarContaSpecificationsValidator>();
			services.AddTransient<DesativarContaSpecificationsValidator>();
			services.AddTransient<MovimentarRecursoEntreContasSpecificationsValidator>();

			return services;
		}
	}
}
