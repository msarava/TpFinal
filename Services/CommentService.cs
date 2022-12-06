using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;

namespace LeBonCoin_Toulouse.Services
{
    public class CommentService
    {
        private CommentRepository _commentRepository;
        private ArticleRepository _articleRepository;
        private UserAppRepository _userAppRepository;

        public CommentService(CommentRepository commentRepository, ArticleRepository articleRepository, UserAppRepository userAppRepository)
        {
            _commentRepository = commentRepository;
            _articleRepository = articleRepository;
            _userAppRepository = userAppRepository;

        }

        public CommentResponseDTO AddComment(CommentRequestDTO commentRequestDto)
        {
            Article article = _articleRepository.FindById(commentRequestDto.ArticleId);
          
                if (article != null)
                {
                    
                    Comment comment = new Comment()
                    {
                        Article = article,
                        Text = commentRequestDto.Text,
                        StatusCom = "Pending",
                        UserAppId = commentRequestDto.UserAppId,

                    };

                }
                throw new Exception("Erreur article non trouvé");
            }
         
    }
}
