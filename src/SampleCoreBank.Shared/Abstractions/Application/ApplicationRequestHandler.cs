using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCoreBank.Shared.Abstractions.Application
{
    public abstract class ApplicationRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ApplicationRequest<TResponse>
        where TResponse : ApplicationResponse
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}