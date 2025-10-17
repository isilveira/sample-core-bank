using FluentValidation;

namespace SampleCoreBank.Shared.Abstractions.Application
{
    public class ApplicationRequestValidator<TRequest> : AbstractValidator<TRequest>
        where TRequest : class
    {
    }
}