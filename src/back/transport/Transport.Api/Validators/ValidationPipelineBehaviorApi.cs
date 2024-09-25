using Common.Core.Errors;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Transport.Api.Validators
{
    public class ValidationPipelineBehaviorApi<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationPipelineBehaviorApi(
            IEnumerable<IValidator<TRequest>> validators
            )
        {
            this.validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!validators.Any())
                return await next();

            var valContext = new ValidationContext<TRequest>(request);
            var errors = validators
                .Select(val => val.Validate(valContext))
                .SelectMany(valResult => valResult.Errors)
                .Where(valFailure => valFailure is not null)
                .ToArray();

            if (errors.Any())
            {
                throw new ValidationException("Validation test failure", errors);
            }

            return await next();
        }

        

    }
}
