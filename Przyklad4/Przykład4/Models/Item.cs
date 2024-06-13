using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład4.Models;

[Table("items")]
public class Item
{
    [Key]
    [Column("Id")]
    public int ItemId { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string ItemName { get; set; }
    
    [Column("Weight")]
    public int ItemWeight { get; set; }

    public IEnumerable<Backpack> Backpacks { get; set; }
}