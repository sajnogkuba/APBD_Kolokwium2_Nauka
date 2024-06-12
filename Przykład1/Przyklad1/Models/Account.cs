using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przyklad1.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountID { get; set; }
    
    [Column("FK_role")]
    public int RoleID { get; set; }
    
    [Column("first_name")]
    [MaxLength(50)]
    public string AccountFirstName { get; set; }
    
    [Column("last_name")]
    [MaxLength(50)]
    public string AccountLastName { get; set; }
    
    [Column("email")]
    [MaxLength(80)]
    public string AccountEmail { get; set; }
    
    [Column("phone")]
    [MaxLength(9)]
    public string? AccountPhone { get; set; }

    public Role Role { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}