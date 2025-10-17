using SampleCoreBank.Core.Domain.CoreBank.Specifications;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations
{
    
    public class CadastrarContaSpecificationsValidator : DomainValidator<Conta>
    {
        public CadastrarContaSpecificationsValidator(
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