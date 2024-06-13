using FluentValidation;
using Przykład2.Exceptions;
using Przykład2.RequestModels;
using Przykład2.Services;

namespace Przykład2.Endpoints;

public static class MuzykEdpoints
{
    public static void RegisterMuzykEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("muzyk");
        
        group.MapGet("{id:int}", async (int id, IMuzykService service) =>
        {
            try
            {
                return Results.Ok(await service.GetMuzykByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
        
        group.MapPost("", async (CreateMuzykRequestModel data, IMuzykService service, IValidator<CreateMuzykRequestModel> validator) =>
        {
            var validate = await validator.ValidateAsync(data);
            if (!validate.IsValid)
            {
                return Results.ValidationProblem(validate.ToDictionary());
            }
    
            try
            {
                await service.CreateMuzyk(data);
                return Results.NoContent();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}