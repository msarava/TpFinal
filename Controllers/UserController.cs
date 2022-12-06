﻿using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;
using LeBonCoin_Toulouse.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeBonCoin_Toulouse.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserAppService _userAppService;

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                List<UserAppResponseDTO> response = _userAppService.GetAllUsers();
                return Ok(response);
            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }
        }

        [HttpPost("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                UserAppResponseDTO response = _userAppService.GetById(id);
                return Ok(response);
            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyUser(int id, [FromBody] UserAppRequestDTO userAppRequestDTO)
        {
            try
            {
                UserAppResponseDTO response = _userAppService.UpdateUser(id, userAppRequestDTO);
                return Ok(response);
            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }
        }


            [HttpPost()]
        public IActionResult Create([FromBody] UserAppRequestDTO userAppRequestDTO)
        {
            try
            {
                UserAppResponseDTO response = _userAppService.AddUser(userAppRequestDTO);
                return Ok(response);
            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }
        }
    }
}
