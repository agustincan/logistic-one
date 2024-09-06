using Common.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Transport.Api.Middlewares
{
    public interface IExceptionHandler
    {
        ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken);
    }
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var excetionDDetails = exception switch
            {
                ValidationAppException => (Detail: exception.Message, StatusCode: StatusCodes.Status422UnprocessableEntity),
                _ => (Detail: exception.Message, StatusCode: StatusCodes.Status500InternalServerError)
            };

            httpContext.Response.StatusCode = excetionDDetails.StatusCode;

            return await Task.FromResult(true);
        }
    }
}
