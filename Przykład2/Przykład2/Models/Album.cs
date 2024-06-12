using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład2.Models;

[Table("Album")]
public class Album
{
    [Key]
    [Column("IdAlbum")]
    public int IdAlbum { get; set; }
    
    [Column("NazwaAlbumu")]
    [MaxLength(30)]
    public string NazwaAlbumu { get; set; }
    
    [Column("DataWydania")]
    public DateTime DataWydania { get; set; }
    
    [Column("IdWytwornia")]
    [ForeignKey("Wytwornia")]
    public int IdWytwornia { get; set; }
    
    public IEnumerable<Utwor> Utwory { get; set; }
    
    public Wytwornia Wytwornia { get; set; }
}