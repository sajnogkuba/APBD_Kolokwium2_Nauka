using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Characters")]
public class Character
{
    [Key]
    [Column("PK")]
    public int CharacterPK { get; set; }
    
    [Column("first_name")]
    [MaxLength(50)]
    public string CharacterFirstName { get; set; }
    
    [Column("last_name")]
    [MaxLength(50)]
    public string CharacterLastName { get; set; }
    
    [Column("current_weig")]
    public int CharacterCurrentWeight { get; set; }
    
    [Column("max_weight")] 
    public int CharacterMaxWeight { get; set; }
    
    [Column("money")] 
    public int CharacterMoney { get; set; }
    
    public IEnumerable<BackpackSlot> BackpackSlots { get; set; }
    
    public IEnumerable<CharacterTitle> CharacterTitles { get; set; }
}