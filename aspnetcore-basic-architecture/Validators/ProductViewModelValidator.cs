using AspnetCoreBasicArchitecture.ViewModel;
using FluentValidation;

namespace AspnetCoreBasicArchitecture.Validators
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(r => r.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product code is not empty !");
            RuleFor(r => r.Code)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Greater then or equal to 1");
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product name is not empty !");
        }
    }
}
