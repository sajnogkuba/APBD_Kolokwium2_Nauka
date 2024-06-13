using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład3.Models;

[Table("BoatStandard")]
public class BoatStandard
{
    [Key]
    [Column("IdBoatStandard")]
    public int BoatStandardId { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string BoatStandardName { get; set; }
    
    [Column("Level")]
    public int BoatStandardLevel { get; set; }
    
    public IEnumerable<Reservation> Reservations { get; set; }
    public IEnumerable<Sailboat> Sailboats { get; set; }
}