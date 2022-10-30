using Common.Core.Collections;
using Common.Core.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Service.EventHandler.Command;
using Transport.Service.EventHandler.Queries;

namespace Transport.Api.Controllers
{
    //[Route("transport")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion("1.0")]
    public class TransportController : BaseApiController<TransportController>
    {

        public TransportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<DataCollection<TransportDto>> Get(int page = 1, int take = 20)
        {
            return await mediator.Send(new TransportListAll() { Page = page, Take = take });
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
