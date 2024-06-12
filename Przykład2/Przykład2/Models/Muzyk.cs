using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład2.Models;

[Table("Muzyk")]
public class Muzyk
{
    [Key]
    [Column("id_muzyk")]
    public int IdMuzyk { get; set; }
    
    [Column("Imie")]
    [MaxLength(30)]
    public string Imie { get; set; }
    
    [Column("Nazwisko")]
    [MaxLength(40)]
    public string Nazwisko { get; set; }
    
    [Column("Pseudonim")]
    [MaxLength(50)]
    public string? Pseudonim { get; set; }
    
    public IEnumerable<WykonawcaUtwor> WykonawcyUtwor { get; set; }
}