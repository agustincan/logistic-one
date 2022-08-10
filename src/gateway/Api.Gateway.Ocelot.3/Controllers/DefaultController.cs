using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Gateway.Ocelot._3.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {

        public DefaultController()
        {
            
        }

        [HttpGet]
        public string Get()
        {
            return "Running ocelot 3 ...";
        }
    }
}
