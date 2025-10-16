using SampleCoreBank.Shared.Abstractions.Domain.Validations;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using FluentValidation;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations
{
    public class DesativacaoContaValidator : EntityValidator<DesativacaoConta>
    {
        public DesativacaoContaValidator() 
        {
            RuleFor(p => p.DocumentoTitular).NotNull().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.DocumentoTitular).NotEmpty().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.Responsavel).NotNull().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.Responsavel).NotEmpty().WithMessage("'{0}' é obrigatório!");
        }
    }
}