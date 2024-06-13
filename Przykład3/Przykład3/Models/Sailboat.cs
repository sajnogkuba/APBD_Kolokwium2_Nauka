using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład3.Models;

[Table("Sailboat")]
public class Sailboat
{
    [Key]
    [Column("IdSailboat")]
    public int SailboatId { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string SailboatName { get; set; }
    
    [Column("Capacity")]
    public int SailboatCapacity { get; set; }
    
    [Column("Description")]
    [MaxLength(100)]
    public string SailboatDescription { get; set; }
    
    [Column("IdBoatStandard")]
    [ForeignKey("BoatStandard")]
    public int SailboatBoatStandardId { get; set; }
    
    [Column("Price", TypeName = "money")]
    public double SailboatPrice { get; set; }
    
    public BoatStandard BoatStandard { get; set; }
    
}