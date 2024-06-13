using FluentValidation;
using Przykład2.RequestModels;

namespace Przykład2.Validators;

public class CrateMuzykModelValidator : AbstractValidator<CreateMuzykRequestModel>
{
    public CrateMuzykModelValidator()
    {
        RuleFor(e => e.Imie).MaximumLength(30).NotEmpty();
        RuleFor(e => e.Nazwisko).MaximumLength(40).NotEmpty();
        RuleFor(e => e.Pseudonim).MaximumLength(50);
    }
}

public class CreateUtworModelValidator : AbstractValidator<CreateUtworRequestModel>
{
    public CreateUtworModelValidator()
    {
        RuleFor(e => e.Tytul).MaximumLength(30).NotEmpty();
        RuleFor(e => e.CzasTrwania).NotNull();
        RuleFor(e => e.IdAlbum).NotNull();
    }
}