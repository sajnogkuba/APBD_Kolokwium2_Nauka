using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Items")]
public class Item
{
    [Key]
    [Column("PK")]
    public int ItemPK { get; set; }
    
    [Column("name")]
    [MaxLength(50)]
    public string ItemName { get; set; }
    
    [Column("weig")]
    public int ItemWeight { get; set; }

    public IEnumerable<BackpackSlot> BackpackSlots { get; set; }
}