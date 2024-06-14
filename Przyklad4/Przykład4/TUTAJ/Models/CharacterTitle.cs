using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[Table("Characters_Titles")]
[PrimaryKey(nameof(CharacterFK), nameof(TitleFK))]
public class CharacterTitle
{
    [Column("FK_character")]
    [ForeignKey("Characters")]
    public int CharacterFK { get; set; }
    
    [Column("FK_title")]
    [ForeignKey("Titles")]
    public int TitleFK { get; set; }
    
    [Column("aquire_at")]
    public DateTime CharacterTitleAquireAt { get; set; }
    
    public Character Character { get; set; }
    
    public Title Title { get; set; }
}