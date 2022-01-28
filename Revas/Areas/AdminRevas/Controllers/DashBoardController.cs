using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace Revas.Areas.AdminRevas.Controllers
{
    [Area("AdminRevas")]

    public class DashBoardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
