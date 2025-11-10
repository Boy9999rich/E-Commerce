using FluentValidation;
using ProductServic.Dtos;

namespace ProductService.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator() 
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.StockCount)
                .GreaterThanOrEqualTo(0).WithMessage("Stock count cannot be negative.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(200).WithMessage("Image URL must not exceed 200 characters.")
                .When(x => !string.IsNullOrEmpty(x.ImageUrl));
        }
    }
}
