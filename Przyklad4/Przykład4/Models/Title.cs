using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład4.Models;

[Table("titles")]
public class Title
{
    [Key]
    [Column("Id")]
    public int TitleId { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string TitleName { get; set; }
    
    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}