using Przyklad1.Exceptions;
using Przyklad1.Services;

namespace Przyklad1.Endpoints;

public static class ProductEndpoints
{
    public static void RegisterProductEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("products");
        
    }
}