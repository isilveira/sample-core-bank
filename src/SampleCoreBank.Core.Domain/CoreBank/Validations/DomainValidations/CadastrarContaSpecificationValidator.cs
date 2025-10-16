using SampleCoreBank.Core.Domain.CoreBank.Abstractions.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations
{
    
    public class CadastrarContaSpecificationValidator : DomainValidator<Conta>
    {
        public CadastrarContaSpecificationValidator(
            NaoPermitirCadastrarContaComMesmoDocumentoSpecification naoPermitirCadastrarContaComMesmoDocumentoSpecification
        )
        {
            Add(
                nameof(naoPermitirCadastrarContaComMesmoDocumentoSpecification),
                new DomainRule<Conta>(
                    naoPermitirCadastrarContaComMesmoDocumentoSpecification.Not(),
                    naoPermitirCadastrarContaComMesmoDocumentoSpecification.ToString()
                )
            );
        }
    }
}