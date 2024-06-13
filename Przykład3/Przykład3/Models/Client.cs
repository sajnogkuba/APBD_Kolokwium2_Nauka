using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przykład3.Models;

[Table("Client")]
public class Client
{
    [Key]
    [Column("IdClient")]
    public int ClientId { get; set; }
    
    [Column("Name")]
    [MaxLength(100)]
    public string ClientName { get; set; }
    
    [Column("LastName")]
    [MaxLength(100)]
    public string ClientLastName { get; set; }
    
    [Column("Birthday")]
    public DateTime ClientBirthday { get; set; }
    
    [Column("Pesel")]
    [MaxLength(100)]
    public string ClientPesel { get; set; }
    
    [Column("Email")]
    [MaxLength(100)]
    public string ClientEmail { get; set; }
    
    [Column("IdClientCategory")]
    [ForeignKey("ClientCategory")]
    public int ClientCategoryId { get; set; }
    
    public ClientCategory ClientCategory { get; set; }
}