using FluentValidation;
using Kolokwium2.RequestModels;

namespace Kolokwium2.Validators;

public class AddItemsRequestModelValidator : AbstractValidator<AddItemsRequestModel>
{
    public AddItemsRequestModelValidator()
    {
        RuleFor(item => item.Items).NotNull().NotEmpty();
    }
}