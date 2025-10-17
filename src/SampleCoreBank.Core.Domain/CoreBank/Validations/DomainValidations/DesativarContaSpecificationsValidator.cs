using SampleCoreBank.Core.Domain.CoreBank.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations
{
    
    public class DesativarContaSpecificationsValidator : DomainValidator<DesativacaoConta>
    {
        public DesativarContaSpecificationsValidator(
            ContaExisteSpecification contaExisteSpecification
        )
        {
            Add(
                nameof(contaExisteSpecification),
                new DomainRule<DesativacaoConta>(
                    contaExisteSpecification,
                    contaExisteSpecification.ToString()
                )
            );
        }
    }
}