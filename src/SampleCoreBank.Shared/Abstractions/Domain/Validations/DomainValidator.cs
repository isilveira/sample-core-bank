using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Shared.Abstractions.Domain.Validations
{
	public abstract class DomainValidator<TEntity> : Validator<TEntity>
		where TEntity : class
	{
    }
}