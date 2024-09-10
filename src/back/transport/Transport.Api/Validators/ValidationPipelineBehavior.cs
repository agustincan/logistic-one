using Common.Core.Errors;
using Common.Core.Results;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Transport.Api.Validators
{
    public class ValidationPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationPipelineBehavior(
            IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!validators.Any())
                return await next();
            var errors = validators
                .Select(val => val.Validate(request))
                .SelectMany(valResult => valResult.Errors)
                .Where(valFailure => valFailure is not null)
                .Select(fail => new Error(
                    fail.PropertyName,
                    fail.ErrorMessage
                ))
                .Distinct()
                .ToArray();

            if (errors.Any())
            {
                return CreateValidationResult<TResponse>(errors);
            }

            return await next();
        }

        private static TResult CreateValidationResult<TResult>(Error[] errors)
            where TResult : class
        {
            if (typeof(TResult) == typeof(Result))
            {
                return ValidationRes.WithErrors(errors) as TResult;
            }

            var result = typeof(ValidationRes)
                .GetGenericTypeDefinition()
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetMethod(nameof(ValidationRes.WithErrors))
                .Invoke(null, new object[] { errors });

            return (TResult)result;
        }

    }
}
