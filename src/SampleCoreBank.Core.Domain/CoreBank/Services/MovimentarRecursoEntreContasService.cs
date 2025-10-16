using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Core.Domain.CoreBank.Validations.DomainValidations;
using SampleCoreBank.Core.Domain.CoreBank.Validations.EntityValidations;
using SampleCoreBank.Shared.Abstractions.Domain.Services;
using Microsoft.Extensions.Localization;

namespace SampleCoreBank.Core.Domain.CoreBank.Abstractions.Services
{
    public class MovimentarRecursoEntreContasServiceRequest : DomainServiceRequest<Movimentacao>
    {
        public MovimentarRecursoEntreContasServiceRequest(Movimentacao payload) : base(payload)
        {
        }
    }
    public class MovimentarRecursoEntreContasServiceRequestHandler : DomainServiceRequestHandler<Movimentacao, MovimentarRecursoEntreContasServiceRequest>
    {
        private ICoreBankDbContextWriter Writer { get; set; }
        public MovimentarRecursoEntreContasServiceRequestHandler(
            ICoreBankDbContextWriter writer,
            IStringLocalizer<MovimentarRecursoEntreContasServiceRequestHandler> localizer,
            MovimentacaoValidator entityValidator,
            MovimentarRecursoEntreContasSpecificationValidator domainValidator)
            : base(localizer, entityValidator, domainValidator)
        {
            Writer = writer;
        }

        public override async Task<Movimentacao> Handle(MovimentarRecursoEntreContasServiceRequest request, CancellationToken cancellationToken)
        {
            ValidateEntity(request.Payload);

            ValidateDomain(request.Payload);

            var contaDebitada = Writer.Query<Conta>().FirstOrDefault(c => c.DocumentoTitular == request.Payload.DocumentoTitularDebitado);
            var contaCreditada = Writer.Query<Conta>().FirstOrDefault(c => c.DocumentoTitular == request.Payload.DocumentoTitularCreditado);

            contaCreditada.Saldo += request.Payload.Valor;
            contaDebitada.Saldo -= request.Payload.Valor;

            await Writer.AddAsync(request.Payload);

            return request.Payload;
        }
    }
}