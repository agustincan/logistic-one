using Common.Core.Collections;
using Common.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Service.EventHandler.Command;
using Transport.Service.EventHandler.Queries;

namespace Transport.Api.Controllers
{
    [ApiController]
    [Route("transport")]
    public class TransportController : BaseApiGenericController<TransportController>
    {

        public TransportController()
        {
            
        }
        
        [HttpGet]
        public async Task<DataCollection<TransportDto>> Get(int page = 1, int take = 10)
        {
            return await mediator.Send(new TransportListAll() { });
        }

        [HttpGet("{id}")]
        public async Task<TransportDto> GetById(int id)
        {
            return await mediator.Send(new TransportGetById() { id = id });
        }

        [HttpGet("license/{license}")]
        public async Task<DataCollection<TransportDto>> GetByLicense(string license)
        {
            return await mediator.Send(new TransportGetByLicense() { License = license });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransportCreateCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(new { id = res });
        }
    }
}
