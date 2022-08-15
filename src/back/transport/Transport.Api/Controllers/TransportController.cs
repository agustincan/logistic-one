using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System.Threading.Tasks;
using Transport.Persistence;
using Transport.Service.EventHandler.Command;
using Transport.Service.Queries;
using Transport.Service.Queries.Dtos;

namespace Transport.Api.Controllers
{
    [ApiController]
    [Route("transport")]
    public class TransportController : Controller
    {
        private readonly AppDbContext context;
        private readonly ITransportQueries queryService;
        private readonly ILogger<TransportController> logger;
        private readonly IMediator mediator;

        public TransportController(AppDbContext context, ITransportQueries queryService, IMediator mediator ,ILogger<TransportController> logger)
        {
            this.context = context;
            this.queryService = queryService;
            this.logger = logger;
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<DataCollection<TransportDto>> Get(int page = 1, int take = 10)
        {
            return await queryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<TransportDto> GetById(int id)
        {
            return await queryService.GetByIdAsync(id);
        }

        [HttpGet("license/{license}")]
        public async Task<DataCollection<TransportDto>> GetByLicense(string license)
        {
            return await queryService.GetByLicenseAsync(license);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransportCreateCommand2 command)
        {
            var res = await mediator.Send(command);
            return Ok(new { id = res.Id });
        }
    }
}
