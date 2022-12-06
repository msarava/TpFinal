using System.ComponentModel.DataAnnotations.Schema;

namespace LeBonCoin_Toulouse.Models
{
    [Table("article")]
    public class Article
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("add_date")]
        public DateTime AddDate { get; set; }
        [Column("statut_article")]
        public bool StatusArticle { get; set; }

        //List Images
        public List<Image> Images { get; set; }

        //List Comments
        public List<Comment> Comments { get; set; }

        //ForeignKey User
        public UserApp User { get; set; }
        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        //ForeignKey Category
        public Category Category { get; set; }
        [ForeignKey("Category")]
        [Column("category_id")]
        public int CategoryId { get; set; }

    }
}
