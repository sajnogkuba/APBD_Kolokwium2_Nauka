using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład2.Models;

[Table("Utwor")]
public class Utwor
{
    [Key]
    [Column("IdUtwor")]
    public int IdUtwor { get; set; }
    
    [Column("NazwaUtworu")]
    [MaxLength(30)]
    public string NazwaUtworu { get; set; }
    
    [Column("CzasTrwania")]
    public float CzasTrwania { get; set; }
    
    [Column("IdAlbum")]
    [ForeignKey("Album")]
    public int IdAlbum { get; set; }
    
    public Album Album { get; set; }
    
    public IEnumerable<WykonawcaUtwor> WykonawcyUtwor { get; set; }
}