using Przyklad1.RequestModels;

namespace Przyklad1.Services;

public interface IProductService
{
    public void AddProduct(PostProductRequest data);
}


public class ProductService : IProductService
{
    public void AddProduct(PostProductRequest data)
    {
        throw new NotImplementedException();
    }
}