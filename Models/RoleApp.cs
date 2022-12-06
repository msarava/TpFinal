using System.ComponentModel.DataAnnotations.Schema;

namespace LeBonCoin_Toulouse.Models
{
    [Table("role_app")]
    public class RoleApp
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("role")]
        public string Role { get; set; }
    }
}
