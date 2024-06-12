using Przyklad1.Context;
using Przyklad1.Exceptions;
using Przyklad1.Models;
using Przyklad1.RequestModels;

namespace Przyklad1.Services;

public interface IProductService
{
    public void AddProduct(PostProductRequest data);
}


public class ProductService(DataBaseContext context) : IProductService
{
    public void AddProduct(PostProductRequest data)
    {
        var newProduct = new Product
        {
            ProductName = data.productName,
            ProductWeight = data.productWeight,
            ProductWidth = data.productWidth,
            ProductHeight = data.productHeight,
            ProductDepth = data.productDepth
        };
        
        context.Products.Add(newProduct);
        context.ProductsCategories.AddRange(data.productCategories.Select(e => new ProductCategory
        {
            Product = newProduct,
            Category = context.Categories.FirstOrDefault(category => category.CategoryID == e) 
                       ?? throw new NotFoundException($"Category with id:{e} does not exist")
        }));
        
        context.SaveChanges();
    }
}