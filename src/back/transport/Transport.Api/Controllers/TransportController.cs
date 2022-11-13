using Common.Core.Collections;
using Common.Core.Controllers;
using Common.Core.Mapping;
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
            var result = await mediator.Send(new TransportListAll() { Page = page, Take = take });
            return result.MapTo<DataCollection<TransportDto>>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resultOption = await mediator.Send(new TransportGetById() { id = id });
            //resultOption.Filter(x => x.Status == Common.Core.Domain.StatusType.Enabled);
            var result = resultOption.Map(r => r.MapTo<TransportDto>());
            return result.Match<IActionResult>(Ok, NotFound);
        }

        [HttpGet("license/{license}")]
        public async Task<DataCollection<TransportDto>> GetByLicense(string license)
        {
            var result = (await mediator.Send(new TransportGetByLicense() { License = license }));
            return result.MapTo<DataCollection<TransportDto>>();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransportCreateCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(new { id = res });
        }
    }
}
