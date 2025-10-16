using MediatR;

namespace SampleCoreBank.Shared.Abstractions.Domain.Interfaces
{
    public interface IDomainService<TEntity>
        where TEntity : class
    {
        Task Run(TEntity entity);
    }

    public interface IDomainService<TEntity, TRequest>
        : IRequestHandler<TRequest, TEntity>
        where TRequest : IRequest<TEntity>
        where TEntity : class
    {
    }
}