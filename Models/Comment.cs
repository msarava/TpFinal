using System.ComponentModel.DataAnnotations.Schema;

namespace LeBonCoin_Toulouse.Models
{
    [Table("comment")]
    public class Comment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("text")]
        public string Text { get; set; }
        [Column("status_com")]
        public string StatusCom { get; set; }

        //ForeignKey UserApp
        public UserApp UserApp { get; set; }
        [ForeignKey("UserApp")]
        [Column("user_app_id")]
        public int UserAppId { get; set; }

        //ForeignKey Article
        public Article Article { get; set; }
        [ForeignKey("Article")]
        [Column("article_id")]
        public int ArticleId { get; set; }
    }
}
