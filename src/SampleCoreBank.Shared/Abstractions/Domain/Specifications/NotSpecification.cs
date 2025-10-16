using System.Linq.Expressions;

namespace SampleCoreBank.Shared.Abstractions.Domain.Specifications
{

    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;
        public NotSpecification(Specification<T> specification) : base()
        {
            _specification = specification;
            SpecificationMessage = specification.ToString();
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> expression = _specification.ToExpression();
            return Expression.Lambda<Func<T, bool>>(Expression.Not(expression.Body), new ParameterExpression[1] { expression.Parameters.Single() });
        }
    }
}