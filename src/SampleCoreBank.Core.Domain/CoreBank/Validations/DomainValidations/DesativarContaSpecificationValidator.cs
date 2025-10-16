using SampleCoreBank.Core.Domain.CoreBank.Abstractions.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations
{
    
    public class DesativarContaSpecificationValidator : DomainValidator<DesativacaoConta>
    {
        public DesativarContaSpecificationValidator(
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