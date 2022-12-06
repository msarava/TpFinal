using LeBonCoin_Toulouse.Models;

namespace LeBonCoin_new.DTOs
{
    public class ArticleRequestDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price {  get; set; }

        public List<Image> Images { get; set; }
        
        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}
