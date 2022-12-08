using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Repositories;
using LeBonCoin_Toulouse.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeBonCoin_Toulouse.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

     //   [Authorize("admin")]
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                List<ArticleResponseDTO> response = _articleService.GetAll();
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }


        }

      //  [Authorize("admin")]
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {

            try
            {
                ArticleResponseDTO response = _articleService.GetById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }

        }
        
       // [Authorize("admin")]
        [HttpPut("status/{articleId}")]
        public IActionResult Put(int articleId, ArticleUpdateRequestDTO articleUpdateRequestDto)
        {

            try
            {
                ArticleUpdateResponseDTO response = _articleService.UpdateArticle(articleUpdateRequestDto, articleId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }

        }

       // [Authorize("admin")]
        [HttpPost("{userId}")]
        public IActionResult Post([FromBody] ArticleRequestDTO articleRequestDto, int userId)
        {

            try
            {
                ArticleResponseDTO response = _articleService.AddArticle(articleRequestDto, userId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }

        }

        // [Authorize("user")]
        [HttpPut("{articleId}/image")]
        public IActionResult Put(int articleId, IFormFile img)
        {

            try
            {
                    return Ok(_articleService.AddImage(articleId, img));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }

        }
    }
}
