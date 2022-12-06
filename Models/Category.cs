using System.ComponentModel.DataAnnotations.Schema;

namespace LeBonCoin_Toulouse.Models
{
    [Table("category")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
