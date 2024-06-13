using FluentValidation;
using Przykład4.RequestModels;

namespace Przykład4.Validators;

public class AddItemsRequestModelValidator : AbstractValidator<AddItemsRequestModel>
{
    public AddItemsRequestModelValidator()
    {
        RuleFor(item => item.items).NotNull().NotEmpty();
    }
}