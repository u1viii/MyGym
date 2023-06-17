using FluentValidation;
using MyGym.Application.DTOs.Sports;

namespace MyGym.Application.Validators.Sports
{
    public class CreateSportValidator : AbstractValidator<SportCreateDTO>
    {
        public CreateSportValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ad boş ola bilməz")
                .MinimumLength(3)
                    .WithMessage("Ad minimal 3 hərfdən ibarət olmalıdır");
        }
    }
}
