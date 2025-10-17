using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Core.Domain.CoreBank.Services;
using SampleCoreBank.Shared.Abstractions.Application;
using SampleCoreBank.Shared.Helpers;

namespace SampleCoreBank.Core.Application.Commands
{
    public class MovimentarRecursoCommandResponse : ApplicationResponse
    {
        public MovimentarRecursoCommandResponse(Tuple<int, int, object, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) 
            : base(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7)
        {
        }

        public MovimentarRecursoCommandResponse(object request, object data, string message = "Operação realizada com sucesso!", long? resultCount = null)
            : base(200, 200, request, data, null, message, resultCount)
        {
        }
    }
    public class MovimentarRecursoCommand : ApplicationRequest<MovimentarRecursoCommandResponse>
	{
		public string? DocumentoTitularDebitado { get; set; }
		public string DocumentoTitularCreditado { get; set; }
		public decimal Valor { get; set; }

		public MovimentarRecursoCommand()
        {
        }
    }

    public class MovimentarRecursoCommandHandler : ApplicationRequestHandler<MovimentarRecursoCommand, MovimentarRecursoCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private ICoreBankDbContextWriter Writer { get; set; }
        public MovimentarRecursoCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<MovimentarRecursoCommandHandler> localizer,
            ICoreBankDbContextWriter writer)
        {

            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<MovimentarRecursoCommandResponse> Handle(MovimentarRecursoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var data = new Movimentacao()
                {
					DocumentoTitularDebitado = request.DocumentoTitularDebitado,
					DocumentoTitularCreditado = request.DocumentoTitularCreditado,
					Valor = request.Valor
                };

                await Mediator.Send(new MovimentarRecursoEntreContasServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                //await Mediator.Publish(new PostSampleNotification(data));

                return new MovimentarRecursoCommandResponse(request, data, Localizer["Operação realizada com sucesso!"], 1);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<MovimentarRecursoCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new MovimentarRecursoCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}