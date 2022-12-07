using LeBonCoin_Toulouse.DTOs;
using LeBonCoin_Toulouse.Models;
using LeBonCoin_Toulouse.Repositories;
using LeBonCoin_Toulouse.Services;
using LeBonCoin_Toulouse.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeBonCoin_Toulouse.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserAppService _userAppService;
        private ILogin _login;
        public UserController(UserAppService userAppService, ILogin login)
        {
            _userAppService = userAppService;
            _login = login;
        }

        //[Authorize("admin")]
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

        //   [Authorize("admin")]
        [HttpGet("{id}")]
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

        //  [Authorize("admin")]
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

        [Authorize("admin")]
        [HttpPut("status/{id}")]
        public IActionResult ModifyStatusUser(int id, [FromForm] bool status)
        {
            try
            {
                UserAppResponseDTO response = _userAppService.UpdateStatusUser(id, status);
                return Ok(response);
            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }
        }

        //    [Authorize("admin")]
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

        //  [Authorize("admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                return Ok(_userAppService.DeleteUser(id));

            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            try
            {
                LoginResponseDTO response = _login.Login(email, password);
                if (response.Token != null)
                {
                    return Ok(response);
                }
                return StatusCode(401);
            }
            catch (Exception e)
            {
                return NotFound(new { Message = e.Message });
            }


        }

    }

}
