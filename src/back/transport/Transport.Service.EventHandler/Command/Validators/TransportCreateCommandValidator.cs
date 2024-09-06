using FluentValidation;

namespace Transport.Service.EventHandler.Command.Validators
{
    public class TransportCreateCommandValidator : AbstractValidator<TransportCreateCommand>
    {
        public TransportCreateCommandValidator()
        {
            RuleFor(r => r.License).NotEmpty().WithMessage("License is mandatory");
        }
    }
}
