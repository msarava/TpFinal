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
                if (_commentRepository.Save(comment))
                {
                    return new CommentResponseDTO()
                    {
                        Id = comment.Id,
                        Text = comment.Text,
                        ArticleId = comment.ArticleId,
                        StatusCom = comment.StatusCom,
                        UserAppId = comment.UserAppId
                    };
                }
                throw new Exception("Erreur serveur - comment");

                }
                throw new Exception("Erreur article non trouvé");
            }
         
        public List<CommentResponseDTO> GetAll()
        {
            List<CommentResponseDTO> commentList = new List<CommentResponseDTO>();

            _commentRepository.FindAll().ForEach(comment =>
            {
                CommentResponseDTO commentResponseDTO = new()
                {
                    ArticleId = comment.ArticleId,
                    Text = comment.Text,
                    StatusCom = comment.StatusCom,
                    UserAppId = comment.UserAppId,
                    Id = comment.Id
                };
                commentList.Add(commentResponseDTO);
            });
            return commentList;
        }

        public CommentResponseDTO UpdateStatus(CommentUpdateRequestDTO commentUpdateRequestDTO, int id)
        {
            Comment comment = _commentRepository.FindById(id);

            if(comment != null)
            {
                comment.StatusCom = commentUpdateRequestDTO.StatusCom;
                _commentRepository.Update();

                return new CommentResponseDTO()
                {
                    Id= comment.Id,
                    Text = comment.Text,
                    StatusCom = comment.StatusCom,
                    UserAppId = comment.UserAppId,
                    ArticleId = comment.ArticleId
                };
            }
            throw new Exception("Erreur Serveur");
        }
    }
}
