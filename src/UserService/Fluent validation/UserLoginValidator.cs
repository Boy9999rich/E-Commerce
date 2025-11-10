using FluentValidation;
using UserService.Dtos;

namespace UserService.Fluent_validation
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator() 
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(8).WithMessage("Username must be at least 4 characters.")
            .MaximumLength(30).WithMessage("Username must not exceed 30 characters.")
            .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
