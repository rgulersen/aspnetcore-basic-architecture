using AspnetCoreBasicArchitecture.ViewModel;
using FluentValidation;

namespace AspnetCoreBasicArchitecture.Validators
{
    public class UserLoginViewModelValidator:AbstractValidator<UserLoginViewModel>
    {
        public UserLoginViewModelValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Please enter a valid e-mail address.");
            RuleFor(r => r.Password)
                .MinimumLength(8)
                .WithMessage("Password must be 8 chars or more.");
        }
    }
}
