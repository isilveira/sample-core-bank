namespace SampleCoreBank.Shared.Abstractions.Domain.Specifications
{

	public class Rule<T>
	{
		private readonly Specification<T> Specification;
		public string ErrorMessage { get; protected set; }
		public Rule(Specification<T> specification)
		{
			Specification = specification;
			ErrorMessage = specification.ToString();
		}
		public Rule(Specification<T> specification, string errorMessage)
		{
			Specification = specification;
			ErrorMessage = errorMessage;
		}
		public bool Validate(T model)
		{
			bool isSatisfied = Specification.IsSatisfiedBy(model);

			if (string.IsNullOrWhiteSpace(ErrorMessage))
			{
				ErrorMessage = Specification.ToString();
			}

			return isSatisfied;
		}
	}
}