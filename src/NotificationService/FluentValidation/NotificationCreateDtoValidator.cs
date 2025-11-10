using FluentValidation;
using NotificationService.Dtos;

namespace NotificationService.FluentValidation
{
    public class NotificationCreateDtoValidator : AbstractValidator<NotificationCreateDto>
    {
        public NotificationCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.")
                .MaximumLength(500).WithMessage("Message must not exceed 500 characters.");

            // Email yoki PhoneNumber dan kamida bittasi bo‘lishi kerak
            RuleFor(x => x)
                .Must(x => !string.IsNullOrWhiteSpace(x.Email) || !string.IsNullOrWhiteSpace(x.PhoneNumber))
                .WithMessage("Either Email or PhoneNumber must be provided.");

            When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
            {
                RuleFor(x => x.Email!)
                    .EmailAddress().WithMessage("Email must be valid.")
                    .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email format is not correct.");
            });

            When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber), () =>
            {
                RuleFor(x => x.PhoneNumber!)
                    .Matches(@"^\+?[0-9]{9,15}$").WithMessage("Phone number format is invalid. Example: +998901234567");
            });
        }
    }
}
