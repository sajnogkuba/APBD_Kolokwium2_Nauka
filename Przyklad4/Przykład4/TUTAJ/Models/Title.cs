using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Titles")]
public class Title
{
    [Key]
    [Column("PK")]
    public int TitlePK { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string TitleName { get; set; }
    
    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}