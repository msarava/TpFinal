using LeBonCoin_Toulouse.Models;

namespace LeBonCoin_new.DTOs
{
    public class CommentRequestDTO
    {
        public string Text { get; set; }

        public int UserAppId { get; set; }

        public int ArticleId { get; set; }

    }
}
