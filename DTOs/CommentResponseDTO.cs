using LeBonCoin_Toulouse.Models;

namespace LeBonCoin_Toulouse.DTOs
{
    public class CommentResponseDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string StatusCom { get; set; }

        public int UserAppId { get; set; }

        public int? ArticleId { get; set; }

        public UserApp User {  get; set; }
    }
}
