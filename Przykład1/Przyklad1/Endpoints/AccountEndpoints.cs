using Przyklad1.Exceptions;
using Przyklad1.Services;

namespace Przyklad1.Endpoints;

public static class AccountEndpoints
{
    public static void RegisterAccountEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("accounts");

        group.MapGet("{id:int}", async (int id, IAccountService service) =>
        {
            try
            {
                return Results.Ok(await service.GetAccountByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}