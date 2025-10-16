using SampleCoreBank.Shared.Abstractions.Domain.Interfaces;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;
using Microsoft.Extensions.Localization;
using MediatR;

namespace SampleCoreBank.Shared.Abstractions.Domain.Services
{
    public abstract class DomainServiceRequestHandler<TEntity, TRequest> : DomainServiceBase<TEntity>, IDomainService<TEntity, TRequest>
        where TRequest : DomainServiceRequest<TEntity>
        where TEntity : class
    {
        public DomainServiceRequestHandler() : base() { }
        public DomainServiceRequestHandler(IStringLocalizer localizer) : base(localizer) { }
        public DomainServiceRequestHandler(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator) : base(localizer, entityValidator) { }
        public DomainServiceRequestHandler(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator, DomainValidator<TEntity> domainValidator) : base(localizer, entityValidator, domainValidator) { }

        public abstract Task<TEntity> Handle(TRequest request, CancellationToken cancellationToken);
    }
}