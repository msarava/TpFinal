using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Services;
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

        public IActionResult Get()
        {

            //TODO: Add services
            return View();
        }

        public IActionResult Post([FromBody] CommentRequestDTO commentRequestDTO)
        {
            try
            {
                CommentResponseDTO response = _commentService.AddComment(commentRequestDTO);
                return Ok(response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur - comment"});
            }
        }
    }
}
