using LeBonCoin_Toulouse.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LeBonCoin_Toulouse.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private ArticleRepository _articleRepository;

        public ArticleController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult GetAll()
        {
            //TODO: Add services
            return View();
        }

        public IActionResult GetOne()
        {
            //TODO: Add services
            return View();
        }
    }
}
