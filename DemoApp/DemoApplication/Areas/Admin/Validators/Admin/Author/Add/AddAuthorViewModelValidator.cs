using DemoApplication.Areas.Admin.ViewModels.Author;
using FluentValidation;

namespace DemoApplication.Areas.Admin.Validators.Admin.Author.Add
{
    public class AddAuthorViewModelValidator : AbstractValidator<AddAuthorViewModel>
    {
        public AddAuthorViewModelValidator()
        {
            RuleFor(aavm => aavm.Name)
                .NotNull()
                .WithMessage("Name can't be empty")
                .NotEmpty()
                .WithMessage("Name can't be empty")
                .MinimumLength(10)
                .WithMessage("Minimum length should be 10")
                .MaximumLength(45)
                .WithMessage("Maximum length should be 45");
            RuleFor(aavm => aavm.LastName)
                    .NotNull()
                    .WithMessage("LastName can't be empty")
                    .NotEmpty()
                    .WithMessage("LastName can't be empty")
                    .MinimumLength(10)
                    .WithMessage("Minimum length should be 10")
                    .MaximumLength(45)
                    .WithMessage("Maximum length should be 45");
        }
    }
}
