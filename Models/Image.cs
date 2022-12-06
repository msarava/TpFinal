using System.ComponentModel.DataAnnotations.Schema;

namespace LeBonCoin_Toulouse.Models
{
    [Table("image")]
    public class Image
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("url")]
        public string Url { get; set; }

        //ForeignKey Article
        public Article Article { get; set; }
        [ForeignKey("Article")]
        [Column("article_id")]
        public int ArticleId { get; set; }
    }
}
