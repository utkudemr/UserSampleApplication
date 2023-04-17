using FluentValidation;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Domain.Service.Validation.FluentValidation
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateUserRequestDto>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Surname).NotEmpty().NotNull();
            RuleFor(x => x.BirthDate).GreaterThan(DateTime.MinValue);
        }
    }
}
