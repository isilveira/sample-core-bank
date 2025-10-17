using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Core.Domain.CoreBank.Services;
using SampleCoreBank.Shared.Abstractions.Application;
using SampleCoreBank.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace SampleCoreBank.Core.Application.Commands
{
    public class BuscarContasQueryResponse : ApplicationResponse
    {
        public BuscarContasQueryResponse(Tuple<int, int, object, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) 
            : base(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7)
        {
        }

        public BuscarContasQueryResponse(object request, object data, string message = "Operação realizada com sucesso!", long? resultCount = null)
            : base(200, 200, request, data, null, message, resultCount)
        {
        }
    }
    public class BuscarContasQuery : ApplicationRequest<BuscarContasQueryResponse>
	{
		public string NomeTitular { get; set; }
		public string DocumentoTitular { get; set; }
		public BuscarContasQuery()
        {

        }
    }

    public class BuscarContasQueryHandler : ApplicationRequestHandler<BuscarContasQuery, BuscarContasQueryResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private ICoreBankDbContextReader Reader { get; set; }
        public BuscarContasQueryHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<BuscarContasQueryHandler> localizer,
            ICoreBankDbContextReader reader)
        {

            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Reader = reader;
        }
        public override async Task<BuscarContasQueryResponse> Handle(BuscarContasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = Reader.Query<Conta>()
                    .Include(c => c.DesativacaoConta)
					.AsNoTracking()
                    .AsQueryable();

                if(!string.IsNullOrWhiteSpace(request.DocumentoTitular))
                    query = query.Where(c => c.DocumentoTitular == request.DocumentoTitular);

				if (!string.IsNullOrWhiteSpace(request.NomeTitular))
					query = query.Where(c => c.NomeTitular.Contains(request.NomeTitular));

                var data = await query.ToListAsync(cancellationToken);

				return new BuscarContasQueryResponse(request, data, Localizer["Operação realizada com sucesso!"], 1);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<BuscarContasQueryHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new BuscarContasQueryResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}