using Microsoft.AspNetCore.Mvc; 

namespace Revas.Areas.AdminRevas.Controllers
{
    [Area("AdminRevas")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
