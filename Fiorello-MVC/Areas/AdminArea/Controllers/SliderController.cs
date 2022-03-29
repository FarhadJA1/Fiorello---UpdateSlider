using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> slider = await _context.Sliders.ToListAsync();
            return View(slider);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (!slider.Photo.ContentType.Contains("image/")){
                ModelState.AddModelError("Photo", "Photo not found");
                return View();
            }
            if (slider.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = Path.Combine(_environment.WebRootPath, "img", fileName);
            using(FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }
            slider.Image = fileName;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var dbSlider = await _context.Sliders.FindAsync(id);
            if (dbSlider == null) return NotFound();
            string path = Path.Combine(_environment.WebRootPath, "img", dbSlider.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Sliders.Remove(dbSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            Slider slider = await _context.Sliders.Where(m=>m.Id == id).FirstOrDefaultAsync();
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Slider slider)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            
            if (id != slider.Id) return BadRequest();

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Photo not found");
                return View();
            }
            if (slider.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "File size is invalid");
                return View();
            }
            Slider dbSlider = await _context.Sliders.AsNoTracking().Where(m => m.Id == slider.Id).FirstOrDefaultAsync();

            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = Path.Combine(_environment.WebRootPath, "img", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }
            slider.Image = fileName;
            dbSlider.Image = slider.Image;
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            
        }


    }
}
