using System.Runtime.CompilerServices;
using Przykład3.Exceptions;
using Przykład3.Services;

namespace Przykład3.Endpoints;

public static class ClientEndpoints
{
    public static void RegisterClientEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/clients");

        group.MapGet("id:int", async (int id, IClientService clientService) =>
        {
            try
            {
                return Results.Ok(await clientService.GetClientByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}