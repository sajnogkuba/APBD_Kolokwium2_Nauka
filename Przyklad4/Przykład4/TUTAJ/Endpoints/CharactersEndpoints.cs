using FluentValidation;
using Kolokwium2.Exceptions;
using Kolokwium2.RequestModels;
using Kolokwium2.Services;

namespace Kolokwium2.Endpoints;

public static class CharactersEndpoints
{
    public static void RegisterCharacterEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("characters");

        group.MapGet("{id:int}", async (int id, ICharacterService service) =>
        {
            try
            {
                return Results.Ok(await service.GetCharacterByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
        
        group.MapPost("{characterId:int}/backpack", async (int characterId, AddItemsRequestModel data, ICharacterService service, IValidator<AddItemsRequestModel> validator) =>
        {
            try
            {
                var validationResult = validator.Validate(data);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                var result = await service.AddItemsAsync(characterId, data);
                return Results.Created("characters/{id}/backpack", result);
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