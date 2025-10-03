using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Transport.Api.ActionFilters;
using Transport.Api.Services;
using Transport.Service.EventHandler.Command;

namespace Transport.Api.Controllers
{
    public sealed class TransportUowController : _BaseController<TransportUowController>
    {
        private readonly ITransportServiceUow transpService;

        public TransportUowController(
            ITransportServiceUow transpService)
        {
            this.transpService = transpService;
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthActionFilter))]
        public async Task<IActionResult> Create(TransportCreateCommand command)
        {
            var resultOption = await transpService.Insert(command);
            Logger.LogInformation("Transport crated log");
            return Ok(resultOption);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AuthActionFilter))]
        public async Task<IActionResult> Update(int id, TransportUpdateCommand command)
        {
            var updated = await transpService.Update(id, command);
            if (!updated)
                return NotFound();
            return NoContent();
        }
    }
}
