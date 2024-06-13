using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład4.Models;

[Table("backpacks")]
public class Backpack
{
    [Column("CharacterId")]
    [ForeignKey("characters")]
    public int BackpackCharacterId { get; set; }
    
    [Column("ItemId")]
    [ForeignKey("items")]
    public int BackpackItemId { get; set; }
    
    [Column("Amount")]
    public int BackpackAmount { get; set; }

    public Item Item { get; set; }
    
    public Character Character { get; set; }
}