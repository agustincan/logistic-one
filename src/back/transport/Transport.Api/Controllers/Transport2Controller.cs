using Common.Core.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transport.Api.ActionFilters;
using Transport.Api.Services;
using Transport.Service.EventHandler.Command;

namespace Transport.Api.Controllers
{
    public sealed class TransportUowController : BaseApiController<TransportUowController>
    {
        private readonly IMediator mediator;
        private readonly ITransportServiceUow transpService;

        public TransportUowController(
            IMediator mediator,
            ITransportServiceUow transpService): base(mediator)
        {
            this.mediator = mediator;
            this.transpService = transpService;
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthActionFilter))]
        public async Task<IActionResult> Create(TransportCreateCommand command)
        {
            var resultOption = await transpService.Insert(command);

            return Ok(resultOption);
        }
    }
}
