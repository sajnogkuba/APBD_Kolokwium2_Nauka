using FluentValidation;
using Przykład3.RequestModels;

namespace Przykład3.Validators;

public class CreateReservationModelValidator : AbstractValidator<CreateReservationRequestModel>
{
    public CreateReservationModelValidator()
    {
        RuleFor(r => r.IdClient).NotEmpty();
        RuleFor(r => r.DateFrom).NotEmpty();
        RuleFor(r => r.DateTo).NotEmpty();
        RuleFor(r => r.IdBoatStandard).NotEmpty();
        RuleFor(r => r.NumOfBoats).NotEmpty();
    }
}