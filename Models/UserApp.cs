using System.ComponentModel.DataAnnotations.Schema;

namespace LeBonCoin_Toulouse.Models
{
    [Table("user_app")]
    public class UserApp
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("status_user")]
        public bool StatusUser { get; set; }

        //ForeignKey RoleApp
        public RoleApp RoleApp { get; set; }

        [ForeignKey("RoleApp")]
        [Column("role_app_id")]
        public int RoleAppId { get; set; }

    }
}
