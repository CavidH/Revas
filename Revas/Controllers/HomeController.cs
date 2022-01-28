using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revas.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Revas.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var portfolios = await _context.portfolios.Where(p => p.IsDeleted == false).Take(6).ToListAsync();
            HomeVM homeVM = new HomeVM { portfolios = portfolios };
            return View(homeVM);
        }

    }
}
