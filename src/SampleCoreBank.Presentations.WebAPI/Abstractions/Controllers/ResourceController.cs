using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleCoreBank.Shared.Abstractions.Application;

namespace SampleCoreBank.Presentations.WebAPI.Abstractions.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ResourceController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
		public async Task<ActionResult<TResponse>> Send<TResponse>(ApplicationRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
			where TResponse : ApplicationResponse
		{
			return WrapResult(await Mediator.Send(request, cancellationToken));
		}

		public async Task<TResponse> SendRequest<TResponse>(ApplicationRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
			where TResponse : ApplicationResponse
		{
			return await Mediator.Send(request, cancellationToken);
		}

		private ActionResult WrapResult(ApplicationResponse response)
		{
			var objectResult = new ObjectResult(response);

			objectResult.StatusCode = response.StatusCode;

			return objectResult;
		}
	}
}
