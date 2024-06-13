using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład4.Models;

[Table("character_titles")]
public class CharacterTitle
{
    [Column("CharacterId")]
    [ForeignKey("characters")]
    public int CharacterId { get; set; }
    
    [Column("TitleId")]
    [ForeignKey("titles")]
    public int TitleId { get; set; }
    
    [Column("AcquiredAt")]
    public DateTime AcquiredAt { get; set; }
    
    public Character Character { get; set; }
    
    public Title Title { get; set; }
}