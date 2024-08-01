using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Transport.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class _BaseController<T> : ControllerBase
    {
        private ILogger<T> _logger;

        protected ILogger<T> Logger
        {
            get
            {
                if (_logger == null)
                {
                    var loggerFactory = HttpContext.RequestServices.GetService<ILoggerFactory>();
                    _logger = loggerFactory.CreateLogger<T>();
                }
                return _logger  ;
            }
        }
    }
}
