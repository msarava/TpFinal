using LeBonCoin_Toulouse.Models;
using Microsoft.Identity.Client;

namespace LeBonCoin_Toulouse.DTOs
{
    public class ArticleResponseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime AddDate { get; set; }

        public bool StatusArticle { get; set; }

        public List<Image> Images { get; set; }

        public List<Comment> Comments { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}
