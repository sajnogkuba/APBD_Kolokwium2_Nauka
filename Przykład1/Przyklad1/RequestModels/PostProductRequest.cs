namespace Przyklad1.RequestModels;

public class PostProductRequest
{
    public string productName { get; set; }
    public decimal productWeight { get; set; }
    public decimal productWidth { get; set; }
    public decimal productHeight { get; set; }
    public decimal productDepth { get; set; }
    public List<int> productCategories { get; set; }
}