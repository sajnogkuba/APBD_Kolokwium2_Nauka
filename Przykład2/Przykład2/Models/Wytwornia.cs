using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład2.Models;

[Table("Wytwornia")]
public class Wytwornia
{
    [Key]
    [Column("IdWytwornia")]
    public int IdWytwornia { get; set; }
    
    [Column("Nazwa")]
    [MaxLength(50)]
    public string Nazwa { get; set; }
    
    public IEnumerable<Album> Albumy { get; set; }
}