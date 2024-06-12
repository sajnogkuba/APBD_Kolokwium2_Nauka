using Przyklad1.Context;
using Przyklad1.Exceptions;
using Przyklad1.RequestModels;
using Przyklad1.Services;

namespace Przyklad1.Endpoints;

public static class ProductEndpoints
{
    public static void RegisterProductEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("products");
        group.MapPost("", async (PostProductRequest data, IProductService service) =>
        {
            try
            {
                service.AddProduct(data);
                return Results.Created();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}