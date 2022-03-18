using Core.Entity.Entities;
using Core.Entity.ViewModel.Crud;
using Data.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MinuteByMinute.Areas.MinuteAdminPanelArea.Controllers
{
    [Area("MinuteAdminPanelArea")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext Context, IWebHostEnvironment env)
        {
            _context = Context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var fromdb = await _context.Sliders.Where(x=>x.IsDeleted==false).ToListAsync();
            return View(fromdb);
        }

        public async Task<IActionResult> Create(CreateVM model)
        {

            if (!ModelState.IsValid) return View();
            Slider slider = new Slider
            {
                ImageLink = UploadFile(model)
        };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fromdb = await _context.Sliders.FindAsync(id);
            if (fromdb == null)
            {
                NotFound();
            }
            CreateVM update = new CreateVM()
            {
                ImageLink=fromdb.ImageLink
            };
            return View(update);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, CreateVM update)
        {
            if (!ModelState.IsValid) return View();
            var fromdb = await _context.Sliders.FindAsync(id);

 
            if (update.Photo != null)
            {
                if (update.ImageLink != null)
                {
                    string filePath = Path.Combine(_env.WebRootPath, "assets", "img", update.ImageLink);
                    System.IO.File.Delete(filePath);
                }
                fromdb.ImageLink = UploadFile(update);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fromdb = _context.Sliders
                .FirstOrDefault(m => m.Id == id);

           CreateVM update = new CreateVM()
            {
               ImageLink=fromdb.ImageLink
            };
            fromdb.IsDeleted = true;
            if (fromdb == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadFile(CreateVM create)
        {
            string uniqueFileName = null;

            if (create.Photo != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "assets", "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + create.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    create.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
