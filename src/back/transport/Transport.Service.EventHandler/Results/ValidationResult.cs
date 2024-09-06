using Common.Core.Errors;

namespace Transport.Service.EventHandler.Results
{
    public sealed class ValidationResult: Result, IValidationResult
    {
        public Error[] Errors { get;}
        public ValidationResult(Error[] errors): base(false, IValidationResult.ValidationError)
        {
            Errors = errors;
        }

        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
}
