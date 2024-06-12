using Przykład2.Exceptions;
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
        
        
    }
}