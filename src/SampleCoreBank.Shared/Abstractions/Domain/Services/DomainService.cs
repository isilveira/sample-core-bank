using SampleCoreBank.Shared.Abstractions.Domain.Interfaces;
using SampleCoreBank.Shared.Abstractions.Domain.Validations;
using Microsoft.Extensions.Localization;

namespace SampleCoreBank.Shared.Abstractions.Domain.Services
{
    public abstract class DomainService<TEntity> : DomainServiceBase<TEntity>, IDomainService<TEntity>
        where TEntity : class
    {
        public DomainService() : base() { }
        public DomainService(IStringLocalizer localizer) : base(localizer) { }
        public DomainService(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator) : base(localizer, entityValidator) { }
        public DomainService(IStringLocalizer localizer, EntityValidator<TEntity> entityValidator, DomainValidator<TEntity> domainValidator) : base(localizer, entityValidator, domainValidator) { }
        public abstract Task Run(TEntity entity);
    }
}