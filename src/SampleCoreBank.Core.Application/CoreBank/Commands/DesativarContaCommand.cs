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
    public class DesativarContaCommandResponse : ApplicationResponse
    {
        public DesativarContaCommandResponse(Tuple<int, int, object, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) 
            : base(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7)
        {
        }

        public DesativarContaCommandResponse(object request, object data, string message = "Operação realizada com sucesso!", long? resultCount = null)
            : base(200, 200, request, data, null, message, resultCount)
        {
        }
    }
    public class DesativarContaCommand : ApplicationRequest<DesativarContaCommandResponse>
	{
		public string DocumentoTitular { get; set; }
		public string Responsavel { get; set; }
        
		public DesativarContaCommand()
        {
        }
    }

    public class DesativarContaCommandHandler : ApplicationRequestHandler<DesativarContaCommand, DesativarContaCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private ICoreBankDbContextWriter Writer { get; set; }
        public DesativarContaCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<DesativarContaCommandHandler> localizer,
            ICoreBankDbContextWriter writer)
        {

            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<DesativarContaCommandResponse> Handle(DesativarContaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var data = new DesativacaoConta()
                {
                    DocumentoTitular = request.DocumentoTitular,
                    Responsavel = request.Responsavel
                };

                await Mediator.Send(new DesativarContaServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                //await Mediator.Publish(new PostSampleNotification(data));

                return new DesativarContaCommandResponse(request, data, Localizer["Operação realizada com sucesso!"], 1);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<DesativarContaCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new DesativarContaCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}