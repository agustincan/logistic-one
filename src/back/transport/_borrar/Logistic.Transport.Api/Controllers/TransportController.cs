using Logistic.Persistence.Transport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Common.Collection;
using System.Threading.Tasks;
using Transport.Service.Queries;
using Transport.Service.Queries.Dtos;

namespace Logistic.Transport.Api.Controllers
{
    [ApiController]
    [Route("transport")]
    public class TransportController : Controller
    {
        private readonly AppDbContext context;
        private readonly ITransportQueries queryService;
        private readonly ILogger logger;

        public TransportController(AppDbContext context, ITransportQueries queryService ,ILogger<TransportController> logger)
        {
            this.context = context;
            this.queryService = queryService;
            this.logger = logger;
        }
        
        [HttpGet]
        public async Task<DataCollection<TransportDto>> Get(int page = 1, int take = 10)
        {
            return await queryService.GetAllAsync(page, take);
        }

        [HttpGet("{int:id}")]
        public async Task<TransportDto> GetById(int id)
        {
            return await queryService.GetByIdAsync(id);
        }
    }
}
