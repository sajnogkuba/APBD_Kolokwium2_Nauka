using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład3.Models;

[Table("ClientCategory")]
public class ClientCategory
{
    [Key]
    [Column("IdClientCategory")]
    public int ClientCategoryId { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string ClientCategoryName { get; set; }
    
    [Column("DiscountPerc")]
    public int ClientCategoryDiscountPercentage { get; set; }
}