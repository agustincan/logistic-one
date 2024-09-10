using FluentValidation;
using Transport.Api.Dtos;

namespace Transport.Api.Validators
{
    public class TestRequestValidator: AbstractValidator<TestRequest>
    {
        public TestRequestValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("Message not empty");
        }
    }
}
