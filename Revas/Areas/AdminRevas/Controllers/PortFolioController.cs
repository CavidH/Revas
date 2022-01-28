using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revas.Areas.AdminRevas.Controllers
{
    [Area("AdminRevas")]
    public class PortFolioController : Controller
    {
        private AppDbContext _context { get; }

        public PortFolioController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var portfolios = await _context.portfolios.Where(p => p.IsDeleted == false).ToListAsync();
            return View(portfolios);
        }
    }
}
