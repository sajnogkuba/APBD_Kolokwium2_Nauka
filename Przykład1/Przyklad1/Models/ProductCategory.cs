using System.ComponentModel.DataAnnotations.Schema;

namespace Przyklad1.Models;

[Table("Products_Categories")]
public class ProductCategory
{
    [Column("FK_product")]
    [ForeignKey("Products")]
    public int ProductID { get; set; }
    
    [Column("FK_category")]
    [ForeignKey("Categories")]
    public int CategoryID { get; set; }
    
    public Product Product { get; set; }
    
    public Category Category { get; set; }
}