using SampleCoreBank.Shared.Abstractions.Domain.Specifications;

namespace SampleCoreBank.Shared.Abstractions.Domain.Validations
{
	public class DomainRule<TEntity> : Rule<TEntity>
		where TEntity : class
	{
		private readonly Specification<TEntity> Specification;
		public DomainRule(Specification<TEntity> specification, string errorMessage) : base(specification, errorMessage)
		{
			Specification = specification;
		}

	}
}