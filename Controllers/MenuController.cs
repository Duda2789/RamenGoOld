using Microsoft.AspNetCore.Mvc;
using RamenGoApi2.Models;
using RamenGoApi2.Services;

namespace RamenGoApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;

        public MenuController(MenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("broths")]
        public IEnumerable<Broth> GetBroths()
        {
            return _menuService.GetBroths();
        }

        [HttpGet("proteins")]
        public IEnumerable<Protein> GetProteins()
        {
            return _menuService.GetProteins();
        }
    }
}
