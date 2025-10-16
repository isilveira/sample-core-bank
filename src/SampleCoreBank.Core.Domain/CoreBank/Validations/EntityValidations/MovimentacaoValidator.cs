using SampleCoreBank.Shared.Abstractions.Domain.Validations;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using FluentValidation;

namespace SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations
{
    public class MovimentacaoValidator : EntityValidator<Movimentacao>
    {
        public MovimentacaoValidator() 
        {
            RuleFor(p => p.DocumentoTitularDebitado).NotNull().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.DocumentoTitularDebitado).NotEmpty().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.DocumentoTitularCreditado).NotNull().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.DocumentoTitularCreditado).NotEmpty().WithMessage("'{0}' é obrigatório!");
            RuleFor(p => p.Valor).NotNull().WithMessage("'{0}' é obrigatório!");
        }
    }
}