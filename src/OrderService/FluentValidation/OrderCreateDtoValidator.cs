using FluentValidation;
using OrderService.Dtos.OrderDto;

namespace OrderService.FluentValidation
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Order must have at least one item.");

            RuleForEach(x => x.Items)
                .SetValidator(new OrderItemDetailedValidator());
        }
    }
}
