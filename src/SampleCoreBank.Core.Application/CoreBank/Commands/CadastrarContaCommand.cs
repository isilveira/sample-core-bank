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
    public class CadastrarContaCommandResponse : ApplicationResponse
    {
        public CadastrarContaCommandResponse(Tuple<int, int, object, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) 
            : base(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7)
        {
        }

        public CadastrarContaCommandResponse(object request, object data, string message = "Operação realizada com sucesso!", long? resultCount = null)
            : base(200, 200, request, data, null, message, resultCount)
        {
        }
    }
    public class CadastrarContaCommand : ApplicationRequest<CadastrarContaCommandResponse>
	{
		public string NomeTitular { get; set; }
		public string DocumentoTitular { get; set; }
		public CadastrarContaCommand()
        {

        }
    }

    public class CadastrarContaCommandHandler : ApplicationRequestHandler<CadastrarContaCommand, CadastrarContaCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private ICoreBankDbContextWriter Writer { get; set; }
        public CadastrarContaCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<CadastrarContaCommandHandler> localizer,
            ICoreBankDbContextWriter writer)
        {

            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<CadastrarContaCommandResponse> Handle(CadastrarContaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var data = new Conta()
                {
                    DocumentoTitular = request.DocumentoTitular,
                    NomeTitular = request.NomeTitular
                };

                await Mediator.Send(new CadastrarContaServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                //await Mediator.Publish(new PostSampleNotification(data));

                return new CadastrarContaCommandResponse(request, data, Localizer["Operação realizada com sucesso!"], 1);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<CadastrarContaCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new CadastrarContaCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}