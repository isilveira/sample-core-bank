using Microsoft.AspNetCore.Mvc;
using SampleCoreBank.Core.Application.Commands;
using SampleCoreBank.Presentations.WebAPI.Abstractions.Controllers;

namespace SampleCoreBank.Presentations.WebAPI.Controllers
{
	public class ContasController : ResourceController
	{
		[HttpGet]
		public async Task<ActionResult<BuscarContasQueryResponse>> BuscarContas([FromQuery] BuscarContasQuery query, CancellationToken cancellationToken = default)
		{
			return await Send(query, cancellationToken);
		}
		[HttpPost]
		public async Task<ActionResult<CadastrarContaCommandResponse>> CadastrarConta([FromBody] CadastrarContaCommand command, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(command, cancellationToken);
		}

		[HttpPost("{documentoTitular}/desativar")]
		public async Task<ActionResult<DesativarContaCommandResponse>> DesativarConta([FromRoute] string documentoTitular, [FromBody] DesativarContaCommand command, CancellationToken cancellationToken = default(CancellationToken))
		{
			command.DocumentoTitular = documentoTitular;

			return await Send(command, cancellationToken);
		}
		[HttpGet("{documentoTitular}/movimentacoes")]
		public async Task<ActionResult<BuscarMovimentacoesDaContaQueryResponse>> BuscarMovimentacoesDaConta([FromRoute] string documentoTitular, [FromQuery] BuscarMovimentacoesDaContaQuery query, CancellationToken cancellationToken = default)
		{
			return await Send(query, cancellationToken);
		}
		[HttpPost("{documentoTitularDebitado}/transferir-recurso")]
		public async Task<ActionResult<MovimentarRecursoCommandResponse>> TransferirRecurso([FromRoute] string documentoTitularDebitado, [FromBody] MovimentarRecursoCommand command, CancellationToken cancellationToken = default)
		{
			command.DocumentoTitularDebitado = documentoTitularDebitado;

			return await Send(command, cancellationToken);
		}
	}
}
