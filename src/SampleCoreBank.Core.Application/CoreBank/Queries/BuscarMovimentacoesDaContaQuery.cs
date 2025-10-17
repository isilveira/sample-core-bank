using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SampleCoreBank.Core.Domain.CoreBank.Entities;
using SampleCoreBank.Core.Domain.CoreBank.Interfaces.Infrastructures.Data;
using SampleCoreBank.Core.Domain.CoreBank.Services;
using SampleCoreBank.Shared.Abstractions.Application;
using SampleCoreBank.Shared.Abstractions.Domain.Exceptions;
using SampleCoreBank.Shared.Helpers;
using System.Security.AccessControl;

namespace SampleCoreBank.Core.Application.Commands
{
    public class BuscarMovimentacoesDaContaQueryResponse : ApplicationResponse
    {
        public BuscarMovimentacoesDaContaQueryResponse(Tuple<int, int, object, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) 
            : base(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7)
        {
        }

        public BuscarMovimentacoesDaContaQueryResponse(object request, object data, string message = "Operação realizada com sucesso!", long? resultCount = null)
            : base(200, 200, request, data, null, message, resultCount)
        {
        }
    }
    public class BuscarMovimentacoesDaContaQuery : ApplicationRequest<BuscarMovimentacoesDaContaQueryResponse>
	{
		public string? DocumentoTitular { get; set; }
		public BuscarMovimentacoesDaContaQuery()
        {

        }
    }

    public class BuscarMovimentacoesDaContaQueryHandler : ApplicationRequestHandler<BuscarMovimentacoesDaContaQuery, BuscarMovimentacoesDaContaQueryResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private ICoreBankDbContextReader Reader { get; set; }
        public BuscarMovimentacoesDaContaQueryHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<BuscarMovimentacoesDaContaQueryHandler> localizer,
            ICoreBankDbContextReader reader)
        {

            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Reader = reader;
        }
        public override async Task<BuscarMovimentacoesDaContaQueryResponse> Handle(BuscarMovimentacoesDaContaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if(!Reader.Query<Conta>().Include(c=>c.DesativacaoConta).Any(c=>c.DocumentoTitular == request.DocumentoTitular && c.DesativacaoConta == null))
                {
					throw new EntityNotFoundException<Conta>(Localizer);
				}

                var query = Reader.Query<Movimentacao>()
                    .AsNoTracking()
                    .AsQueryable();

                if(!string.IsNullOrWhiteSpace(request.DocumentoTitular))
                    query = query.Where(c => c.DocumentoTitularCreditado == request.DocumentoTitular || c.DocumentoTitularDebitado == request.DocumentoTitular);

                var data = await query
                    .OrderBy(c=>c.DataOperacao)
                    .ToListAsync(cancellationToken);

				return new BuscarMovimentacoesDaContaQueryResponse(request, data, Localizer["Operação realizada com sucesso!"], data != null ? data.Count : 0);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<BuscarMovimentacoesDaContaQueryHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new BuscarMovimentacoesDaContaQueryResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}