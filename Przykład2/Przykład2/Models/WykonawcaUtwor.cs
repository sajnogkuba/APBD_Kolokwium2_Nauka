using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład2.Models;

[Table("WykonawcaUtwor")]
public class WykonawcaUtwor
{
    [Column("IdWMuzyk")]
    [ForeignKey("Muzyk")]
    public int IdWMuzyk { get; set; }
    
    [Column("IdWUtwor")]
    [ForeignKey("Utwor")]
    public int IdUtwor { get; set; }
    
    public Muzyk Muzyk { get; set; }
    
    public Utwor Utwor { get; set; }
}