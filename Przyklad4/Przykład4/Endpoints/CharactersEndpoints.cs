using Przykład4.Exceptions;
using Przykład4.Services;

namespace Przykład4.Endpoints;

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
    }
}