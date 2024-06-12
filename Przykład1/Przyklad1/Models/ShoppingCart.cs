using System.ComponentModel.DataAnnotations.Schema;

namespace Przyklad1.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [ForeignKey("Accounts")]
    [Column("FK_account")]
    public int AccountID { get; set; }
    
    [ForeignKey("Products")]
    [Column("FK_product")]
    public int ProductID { get; set; }
    
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
    
    public Account Account { get; set; }
    
    public Product Product { get; set; }
}