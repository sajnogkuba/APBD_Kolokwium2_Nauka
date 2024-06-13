using FluentValidation;
using Przykład3.Exceptions;
using Przykład3.RequestModels;
using Przykład3.Services;

namespace Przykład3.Endpoints;

public static class ReservationEndpoints
{ 
    public static void RegisterReservationEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/reservations");

        group.MapPost("", async (CreateReservationRequestModel data, IReservationService service, IValidator<CreateReservationRequestModel> validator) =>
        {
            var validationResult = validator.Validate(data);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            try
            {
                var id = await service.CreateReservation(data);
                return Results.Created($"/reservations/{id}", id);
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}