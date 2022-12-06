using LeBonCoin_Toulouse.Repositories;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Services.Interfaces;

namespace LeBonCoin_Toulouse.Services
{
    public class ArticleService
    {
        private ArticleRepository _articleRepository;
        private IUpload _upload;

        public ArticleService(ArticleRepository articleRepository, IUpload upload)
        {
            _articleRepository = articleRepository;
            _upload = upload;
        }

        public ArticleResponseDTO AddArticle(ArticleRequestDTO articleRequestDTO)
        {
            Article article = new Article()
            {
                Title = articleRequestDTO.Title,
                Description = articleRequestDTO.Description,
                Price = articleRequestDTO.Price,
                Images = articleRequestDTO.Images,
                UserId = articleRequestDTO.UserId,
                CategoryId = articleRequestDTO.CategoryId
            };
            if(_articleRepository.Save(article))
            {
                return new ArticleResponseDTO()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Description = article.Description,
                    Price = article.Price,
                    AddDate = article.AddDate,
                    StatusArticle = article.StatusArticle,
                    UserId = article.UserId,
                    CategoryId = article.CategoryId
                };
            }
            throw new Exception("Erreur serveur database");
        }

        public List<ArticleResponseDTO> GetAll()
        {
            List<ArticleResponseDTO> responseDtos = new List<ArticleResponseDTO>();
            _articleRepository.FindAll().ForEach(a =>
            {
                ArticleResponseDTO response = new ArticleResponseDTO()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Price = a.Price,
                    AddDate = a.AddDate,
                    StatusArticle = a.StatusArticle,
                    UserId = a.UserId,
                    CategoryId = a.CategoryId
                };
                a.Images.ForEach(i =>
                {
                    response.Images.Add(new Image(){Url = i.Url });
                });
                a.Comments.ForEach(c =>
                {
                    response.Comments.Add(new Comment() { UserAppId = c.UserAppId, Text = c.Text });
                });
                responseDtos.Add(response);
            });
            return responseDtos;
        }

        public ArticleResponseDTO GetById(int id)
        {
            Article article = _articleRepository.FindById(id);
            if(article != null)
            {
                ArticleResponseDTO response = new ArticleResponseDTO()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Description = article.Description,
                    Price = article.Price,
                    AddDate = article.AddDate,
                    StatusArticle = article.StatusArticle,
                    UserId = article.UserId,
                    CategoryId = article.CategoryId
                };
                article.Images.ForEach(i =>
                {
                    response.Images.Add(new Image() { Url = i.Url });
                });
                article.Comments.ForEach(c =>
                {
                    response.Comments.Add(new Comment() { UserAppId = c.UserAppId, Text = c.Text });
                });
                return response;
            }
            throw new Exception("Aucun article avec cet id");
        }

        public bool AddImage(int id, IFormFile img)
        {
            try
            {
                Article article = _articleRepository.FindById(id);
                if(article != null)
                {
                    Image image = new Image() { Url = _upload.UploadImage(img) };
                    article.Images.Add(image);
                    return _articleRepository.Update();
                }
                throw new Exception("Aucun article avec cet id");
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
