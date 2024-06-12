namespace Przyklad1.ResponseModels;

public class GetAccountResponse
{
    public string  firstName { get; set; }
    public string  lastName { get; set; }
    public string  email { get; set; }
    public string?  phone { get; set; }
    public string  role { get; set; }
    public List<GetAccountCart>  cart { get; set; }
    
    public class GetAccountCart
    {
        public int  productId { get; set; }
        public string  productName { get; set; }
        public int  amount { get; set; }
    }
}