using Microsoft.AspNetCore.Mvc;

namespace Play.Catalog.Service.Controllers
{
    public class ItemsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
