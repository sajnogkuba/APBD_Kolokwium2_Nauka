using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład3.Models;

[Table("Saleboat_Reservation")]
public class SailboatReservation
{
    [Column("IdSailboat")]
    [ForeignKey("Sailboat")]
    public int SailboatReservationSailboatId { get; set; }
    
    [Column("IdReservation")]
    [ForeignKey("Reservation")]
    public int SailboatReservationReservationId { get; set; }

    public Sailboat Sailboat { get; set; }
    
    public Reservation Reservation { get; set; }
}