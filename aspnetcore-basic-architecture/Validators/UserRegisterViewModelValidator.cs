using AspnetCoreBasicArchitecture.ViewModel;
using FluentValidation;

namespace AspnetCoreBasicArchitecture.Validators
{
    public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Please enter a valid e-mail address.");
            RuleFor(r => r.Password)
                .MinimumLength(8)
                .WithMessage("Password must be 8 chars or more.");
            RuleFor(r => r.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username is not empty");
            RuleFor(r => r.Password)
                .Equal(r => r.ConfirmPassword)
                .WithMessage("The Confirm Password confirmation doesn't match.");
        }
    }
}
