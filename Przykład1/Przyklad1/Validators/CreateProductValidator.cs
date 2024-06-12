using FluentValidation;
using Przyklad1.RequestModels;

namespace Przyklad1.Validators;

public class CreateProductValidator : AbstractValidator<PostProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(e => e.productName).MaximumLength(100).NotEmpty();
        RuleFor(e => e.productCategories).NotEmpty();
        RuleFor(e => e.productDepth).NotNull();
        RuleFor(e => e.productHeight).NotNull();
        RuleFor(e => e.productWeight).NotNull();
        RuleFor(e => e.productWidth).NotNull();
    }
}