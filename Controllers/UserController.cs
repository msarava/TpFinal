using Microsoft.AspNetCore.Mvc;

namespace LeBonCoin_Toulouse.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Get()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }
    }
}
