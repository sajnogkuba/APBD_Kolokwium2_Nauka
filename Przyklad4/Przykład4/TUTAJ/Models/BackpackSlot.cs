using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Backpack_Slots")]
public class BackpackSlot
{
    [Key]
    [Column("PK")]
    public int BackpackSlotPK { get; set; }
    
    [Column("FK_item")]
    [ForeignKey("Items")]
    public int ItemFK { get; set; }
    
    [Column("FK_character")]
    [ForeignKey("Characters")]
    public int CharacterFK { get; set; }

    public Item Item { get; set; }

    public Character Character { get; set; }
}