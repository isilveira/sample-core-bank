using FluentValidation;

namespace SampleCoreBank.Shared.Abstractions.Domain.Validations
{
    public abstract class EntityValidator<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {

    }
}