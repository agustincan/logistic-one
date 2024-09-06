using Common.Core.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Transport.Api.Validators
{
    public class ValidationPipelineBehaviorApi<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
       
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            

            return await next();
        }

        

    }
}
