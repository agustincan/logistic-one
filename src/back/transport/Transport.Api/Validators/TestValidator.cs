using FluentValidation;
using FluentValidation.Results;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using Transport.Domain.Models;

namespace Transport.Api.Validators
{
    public class TestValidator: AbstractValidator<Company>
    {
        public TestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Test).Custom((x, context) =>
            {
                if (context.RootContextData.ContainsKey("MyCustomData"))
                {
                    context.AddFailure("My error message");
                }
            });

        }
        //protected override bool PreValidate(ValidationContext<Company> context, ValidationResult result)
        //{
        //    if (context.InstanceToValidate == null)
        //    {
        //        result.Errors.Add(new ValidationFailure("", "Please ensure a model was supplied."));
        //        return false;
        //    }
        //    return true;
        //}
    }

    public static class FluentValidationExtensions
    {
        public static void ValidateAndThrowArgumentException<T>(this IValidator<T> validator, T instance)
        {
            var res = validator.Validate(instance);

            if (!res.IsValid)
            {
                var ex = new ValidationException(res.Errors);
                throw new ArgumentException(ex.Message, ex);
            }
        }
        public static IDictionary<string, string[]> ToDictionary(this ValidationResult validationResult)
        {
            return validationResult.Errors
              .GroupBy(x => x.PropertyName)
              .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
              );
        }
    }
}
