using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Przyklad1.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [ForeignKey("Roles")]
    [Column("PK_role")]
    public int RoleID { get; set; }
    
    [Column("name")]
    [MaxLength(100)]
    public string RoleName { get; set; }
    
    public IEnumerable<Account> Accounts { get; set; }
}