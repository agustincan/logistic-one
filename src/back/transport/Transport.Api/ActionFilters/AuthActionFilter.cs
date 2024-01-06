using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Transport.Api.ActionFilters
{
    public class AuthActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<AuthActionFilter> logger;

        public AuthActionFilter(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<AuthActionFilter>();
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            logger.LogInformation("Before action filter");
            var req = context.HttpContext.Request;
            var result = await next();
            logger.LogInformation($"After action filter {result}");

        }
    }
}
