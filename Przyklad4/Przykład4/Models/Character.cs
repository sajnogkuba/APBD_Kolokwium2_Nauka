using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład4.Models;

[Table("characters")]
public class Character
{
    [Key]
    [Column("Id")]
    public int CharacterId { get; set; }
    
    [Column("FirstName")]
    [MaxLength(50)]
    public string CharacterFirstName { get; set; }
    
    [Column("LastName")]
    [MaxLength(120)]
    public string CharacterLastName { get; set; }
    
    [Column("CurrentWei")] 
    public int CharacterCurrentWeight { get; set; }
    
    [Column("MaxWeight")]
    public int CharacterMaxWeight { get; set; }
    
    public IEnumerable<Backpack> Backpacks { get; set; }
    
    public IEnumerable<CharacterTitle> Titles { get; set; }
}