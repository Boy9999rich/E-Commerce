using FluentValidation;
using PaymentService.Dtos;

namespace PaymentService.FluentValidation
{
    public class PaymentCreateDtoValidation : AbstractValidator<PaymentCreateDto>
    {
        public PaymentCreateDtoValidation()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .MaximumLength(50).WithMessage("Payment method must not exceed 50 characters.")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("Payment method can only contain letters and spaces.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email format is not correct.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[0-9]{9,15}$").WithMessage("Phone number format is invalid. Example: +998901234567");
        }

    }
}
