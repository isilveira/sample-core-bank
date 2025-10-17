using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations;
using SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations;
using SampleCoreBank.Shared.Abstractions.Domain.Services;
using Microsoft.Extensions.Localization;

namespace SampleCoreBank.Core.Domain.CoreBank.Services
{
    public class DesativarContaServiceRequest : DomainServiceRequest<DesativacaoConta>
    {
        public DesativarContaServiceRequest(DesativacaoConta payload) : base(payload)
        {
        }
    }
    public class DesativarContaServiceRequestHandler : DomainServiceRequestHandler<DesativacaoConta, DesativarContaServiceRequest>
    {
        private ICoreBankDbContextWriter Writer { get; set; }
        public DesativarContaServiceRequestHandler(
            ICoreBankDbContextWriter writer,
            IStringLocalizer<DesativarContaServiceRequestHandler> localizer,
            DesativacaoContaValidator entityValidator,
            DesativarContaSpecificationsValidator domainValidator)
            : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<DesativacaoConta> Handle(DesativarContaServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            request.Payload.Data = DateTime.Now;

            await Writer.AddAsync(request.Payload);

            return request.Payload;
        }
    }
}