using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Przykład3.Models;

[Table("Reservation")]
public class Reservation
{
    [Key] [Column("IdReservation")] public int ReservationId { get; set; }

    [Column("IdClient")]
    [ForeignKey("Client")]
    public int ReservationClientId { get; set; }

    [Column("DateFrom")] public DateTime ReservationDateFrom { get; set; }

    [Column("DateTo")] public DateTime ReservationDateTo { get; set; }

    [Column("IdBoatStandard")]
    [ForeignKey("BoatStandard")]
    public int ReservationBoatStandardId { get; set; }

    [Column("Capacity")] public int ReservationCapacity { get; set; }

    [Column("NumOfBoats")] public int ReservationNumOfBoats { get; set; }

    [Column("Fulfilled", TypeName = "bit")] 
    public bool ReservationFulfilled { get; set; }
    
    [Column("Price", TypeName = "money")] 
    public decimal ReservationPrice { get; set; }
    
    [Column("CancelReason")]
    [MaxLength(200)]
    public string? ReservationCancelReason { get; set; }


    public Client Client { get; set; }
    
    public BoatStandard BoatStandard { get; set; }
}