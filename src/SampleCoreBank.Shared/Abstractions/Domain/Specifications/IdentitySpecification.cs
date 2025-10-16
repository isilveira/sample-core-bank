using System.Linq.Expressions;

namespace SampleCoreBank.Shared.Abstractions.Domain.Specifications
{

	internal sealed class IdentitySpecification<T> : Specification<T>
	{
		public override Expression<Func<T, bool>> ToExpression()
		{
			return (T x) => true;
		}
	}
}