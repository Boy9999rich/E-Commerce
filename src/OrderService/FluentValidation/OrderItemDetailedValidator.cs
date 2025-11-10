using FluentValidation;
using OrderService.Dtos.OrderItemDto;

namespace OrderService.FluentValidation
{
    public class OrderItemDetailedValidator : AbstractValidator<OrderItemDetailedDto>
    {
        public OrderItemDetailedValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        }

    }
}
