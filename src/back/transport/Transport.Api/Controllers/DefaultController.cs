using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Transport.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        private readonly IOptions<EnvironmentVars> envVars;
        private readonly IOptionsMonitor<EnvironmentVars> monitorEnvVars;

        //private readonly ILogger<DefaultController> _logger;

        public DefaultController(IOptions<EnvironmentVars> envVars,
            IOptionsMonitor<EnvironmentVars> monitorEnvVars)
        {
            this.envVars = envVars;
            this.monitorEnvVars = monitorEnvVars;
        }

        [HttpGet]
        public string Get()
        {
            return "Running...";
        }

        [HttpGet("GetEnviromentOptions")]
        [ProducesResponseType(typeof(EnvironmentVars), 200)]
        public IActionResult GetEnviromentOptions()
        {
            return Ok(new { envVars.Value ,monitorEnvVars.CurrentValue });
        }

        [HttpGet("GetEnviromentOptionsWithSetup")]
        [ProducesResponseType(typeof(EnvironmentVars), 200)]
        public IActionResult GetEnviromentOptionsWithSetup()
        {
            return Ok(new { envVars.Value, monitorEnvVars.CurrentValue });
        }
    }
}
