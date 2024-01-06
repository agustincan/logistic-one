using Api.Gateway.Proxies;
using Common.Core.Collections;
using Microsoft.AspNetCore.Mvc;
using Transport.Domain.Dtos;

namespace Api.Gateway.WebClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly ILogger<DefaultController> logger;
        private readonly ITransportApiProxy transportApiProxy;

        public TransportController(ILogger<DefaultController> logger, ITransportApiProxy transportApiProxy )
        {
            this.logger = logger;
            this.transportApiProxy = transportApiProxy;
        }

        [HttpGet]
        public async Task<DataCollection<TransportDto>> GetAll(int page, int take)
        {
            //var clients = new int[] {1,2};
            return await transportApiProxy.GetAllAsync(page, take);
        }
    }
}