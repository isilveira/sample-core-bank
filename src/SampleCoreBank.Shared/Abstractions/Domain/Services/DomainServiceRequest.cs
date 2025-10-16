using MediatR;

namespace SampleCoreBank.Shared.Abstractions.Domain.Services
{
    public abstract class DomainServiceRequest<TEntity>
        : IRequest<TEntity>
        where TEntity : class
    {
        public TEntity Payload { get; set; }
        public DomainServiceRequest(TEntity payload)
        {
            Payload = payload;
        }
    }
}