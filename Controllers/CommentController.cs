using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeBonCoin_Toulouse.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

      //  [Authorize("admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<CommentResponseDTO> response = _commentService.GetAll();
                return Ok(response);
            } catch(Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur" });
            }
        }

      //  [Authorize("user")]
        [HttpPost("{articleId}")]
        public IActionResult Post([FromBody] CommentRequestDTO commentRequestDTO, int articleId)
        {
            try
            {
                CommentResponseDTO response = _commentService.AddComment(commentRequestDTO, articleId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }
        }

      //  [Authorize("admin")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CommentUpdateRequestDTO commentUpdateRequestDTO, int id)
        {
            try
            {
                CommentResponseDTO response = _commentService.UpdateStatus(commentUpdateRequestDTO, id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }
        }
    }
}
