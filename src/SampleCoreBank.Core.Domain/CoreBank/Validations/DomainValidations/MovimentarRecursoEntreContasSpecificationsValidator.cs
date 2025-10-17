using SampleCoreBank.Core.Domain.CoreBank.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations
{
    
    public class MovimentarRecursoEntreContasSpecificationsValidator : DomainValidator<Movimentacao>
    {
        public MovimentarRecursoEntreContasSpecificationsValidator(
            MovimetacaoContaDebitadaEhValidaSpecification movimetacaoContaDebitadaEhValidaSpecification,
            MovimetacaoContaCreditadaEhValidaSpecification movimetacaoContaCreditadaEhValidaSpecification,
            MovimetacaoVerificaSaldoContaDebitadaSpecification movimetacaoVerificaSaldoContaDebitadaSpecification
        )
        {
            Add(
                nameof(movimetacaoContaDebitadaEhValidaSpecification),
                new DomainRule<Movimentacao>(
                    movimetacaoContaDebitadaEhValidaSpecification,
                    movimetacaoContaDebitadaEhValidaSpecification.ToString()
                )
            );
            Add(
                nameof(movimetacaoContaCreditadaEhValidaSpecification),
                new DomainRule<Movimentacao>(
                    movimetacaoContaCreditadaEhValidaSpecification,
                    movimetacaoContaCreditadaEhValidaSpecification.ToString()
                )
            );
            Add(
                nameof(movimetacaoVerificaSaldoContaDebitadaSpecification),
                new DomainRule<Movimentacao>(
                    movimetacaoVerificaSaldoContaDebitadaSpecification,
                    movimetacaoVerificaSaldoContaDebitadaSpecification.ToString()
                )
            );
        }
    }
}