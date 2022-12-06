﻿using LeBonCoin_Toulouse.DTOs;
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

        [Authorize("admin")]
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
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }


        }

        [Authorize("admin")]
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
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }

        }
        
        [Authorize("admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ArticleUpdateRequestDTO articleUpdateRequestDto)
        {

            try
            {
                ArticleUpdateResponseDTO response = _articleService.UpdateArticle(articleUpdateRequestDto, id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }

        }

        [Authorize("user")]
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
                return StatusCode(500, new { message = "Erreur serveur - comment" });
            }

        }

    }
}
