using Microsoft.AspNetCore.Mvc;
using SampleCoreBank.Core.Application.Commands;
using SampleCoreBank.Presentations.WebAPI.Abstractions.Controllers;
using System.Threading.Tasks;

namespace SampleCoreBank.Presentations.WebAPI.Controllers
{
	public class ContasController : ResourceController
	{
		[HttpGet]
		public async Task<ActionResult<BuscarContasQueryResponse>> Get([FromBody] BuscarContasQuery query, CancellationToken cancellationToken = default)
		{
			return await Send(query, cancellationToken);
		}
		[HttpPost]
		public async Task<ActionResult<CadastrarContaCommandResponse>> Post([FromBody] CadastrarContaCommand command, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(command, cancellationToken);
		}

		[HttpPost("{documentoTitular}/desativar")]
		public async Task<ActionResult<DesativarContaCommandResponse>> Post([FromRoute, FromBody] DesativarContaCommand command, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(command, cancellationToken);
		}
		[HttpGet("{documentoTitular}/movimentacoes")]
		public async Task<ActionResult<BuscarMovimentacoesDaContaQueryResponse>> Get([FromRoute] BuscarMovimentacoesDaContaQuery query, CancellationToken cancellationToken = default)
		{
			return await Send(query, cancellationToken);
		}
	}
}
