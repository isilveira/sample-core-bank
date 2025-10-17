using SampleCoreBank.Shared.Abstractions.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace SampleCoreBank.Shared.Abstractions.Application
{
    public abstract class ApplicationRequest<TResponse> : IRequest<TResponse>
        where TResponse : ApplicationResponse
    {
        protected ApplicationRequestValidator<ApplicationRequest<TResponse>> Validator { get; set; }
        public ApplicationRequest()
        {
            Validator = new ApplicationRequestValidator<ApplicationRequest<TResponse>>();
        }
        public bool IsValid(IStringLocalizer localizer, bool throwException = true, string message = null)
        {
            var result = this.Validator.Validate(this);

            if (!result.IsValid && throwException)
            {
                throw new BusinessException(
                    message ?? localizer["Falha na validação da requisição!"],
                    result.Errors.Select(error =>
                        new RequestValidationException(localizer[error.PropertyName], string.Format(localizer[error.ErrorMessage], localizer[error.PropertyName]))
                    ).ToList());
            }

            return result.IsValid;
        }
    }
}