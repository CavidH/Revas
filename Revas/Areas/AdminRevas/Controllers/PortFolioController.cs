

using Core.Entities;
using Data.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revas.Areas.AdminRevas.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Revas.Areas.AdminRevas.Controllers
{
    [Area("AdminRevas")]
    public class PortFolioController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }


        public PortFolioController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var portfolios = await _context.portfolios.Where(p => p.IsDeleted == false).ToListAsync();
            return View(portfolios);
        }
        public async Task<IActionResult> Update(int Id)
        {
            var portfolio = await _context.portfolios.Where(p => p.IsDeleted == false && p.Id == Id).FirstOrDefaultAsync();
            if (portfolio == null) return NotFound();
            var UpdateVM = new UpdateVM
            {
                Title = portfolio.Title
            };
            return View(UpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, CreateVM createVM)
        {
            var portfolio = await _context.portfolios.Where(p => p.IsDeleted == false && p.Id == Id).FirstOrDefaultAsync();
            if (portfolio == null) return NotFound();
            portfolio.Title = createVM.Title;
            if (createVM.ImageFile != null)
            {
                var fileName = CreateFile(createVM.ImageFile);
                portfolio.Image = fileName;
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVM createVM)
        {
            if (createVM == null) return NotFound();
            if (ModelState.IsValid)
            {
                var FileName = CreateFile(createVM.ImageFile);
                var portfolio = new Portfolio
                {
                    Title = createVM.Title,
                    Image = FileName
                };
                await _context.AddAsync(portfolio);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View(createVM);
        }
        public async Task<IActionResult> Delete(int Id)
        {

            var portfolio = await _context.portfolios.Where(p => p.IsDeleted == false && p.Id == Id).FirstOrDefaultAsync();
            if (portfolio == null) return NotFound();
            portfolio.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private string CreateFile(IFormFile image)
        {
            string FileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "Assets", "Img");
                FileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return FileName;
        }
    }
}
