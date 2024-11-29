using Common.Core.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Transport.Api.Controllers
{
    public abstract class BaseApiCqrsController<T> : BaseApiController<T>
    {
        private IMediator _mediatorInstance = default!;
        protected IMediator mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>()!;

    }
}
