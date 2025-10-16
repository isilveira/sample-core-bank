using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations;
using SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations;
using SampleCoreBank.Shared.Abstractions.Domain.Services;
using Microsoft.Extensions.Localization;

namespace SampleCoreBank.Core.Domain.CoreBank.Abstractions.Services
{
    public class CadastrarContaServiceRequest : DomainServiceRequest<Conta>
    {
        public CadastrarContaServiceRequest(Conta payload) : base(payload)
        {
        }
    }
    public class CadastrarContaServiceRequestHandler : DomainServiceRequestHandler<Conta, CadastrarContaServiceRequest>
    {
        private ICoreBankDbContextWriter Writer { get; set; }
        public CadastrarContaServiceRequestHandler(
            ICoreBankDbContextWriter writer,
            IStringLocalizer<CadastrarContaServiceRequestHandler> localizer,
            ContaValidator entityValidator,
            CadastrarContaSpecificationValidator domainValidator)
            : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Conta> Handle(CadastrarContaServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            request.Payload.DataAbertura = DateTime.Now;
            request.Payload.Saldo = 1000;

            await Writer.AddAsync(request.Payload);

            return request.Payload;
        }
    }
}