﻿using LeBonCoin_Toulouse.DTOs;
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

        [HttpPost]
        public IActionResult Post([FromBody] CommentRequestDTO commentRequestDTO)
        {
            try
            {
                CommentResponseDTO response = _commentService.AddComment(commentRequestDTO);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] CommentUpdateRequestDTO commentUpdateRequestDTO)
        {
            try
            {
                CommentResponseDTO response = _commentService.UpdateStatus(commentUpdateRequestDTO);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }
        }
    }
}
