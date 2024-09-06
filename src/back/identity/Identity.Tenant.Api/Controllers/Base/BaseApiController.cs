using Common.Core.Controllers;
using MediatR;

namespace Identity.Tenant.Api.Controllers.Base
{
    public abstract class BaseApiCqrsController<T> : BaseApiController<T>
    {
        private IMediator _mediatorInstance = default!;
        protected IMediator mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>()!;

    }
}
