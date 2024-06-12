using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przyklad1.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("PK_category")]
    public int CategoryID { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string CategoryName { get; set; }
    
    public IEnumerable<ProductCategory> ProductCategories { get; set; }
}