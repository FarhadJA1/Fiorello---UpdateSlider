using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Where(m => m.IsDelete == false).ToListAsync();
            return View(categories);
        }
        public IActionResult Detail(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return Json(new { 
            categoryName = category.Name,   
            action = "Detail",
            Id = id
            });
        }
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return Json(new
            {
                categoryName = category.Name,
                action = "Edit",
                Id = id
            });
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(m => m.Id == id);
            return Json(new
            {
                categoryName = category.Name,
                action = "Delete",
                Id = id
            });
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = _context.Categories.Any(m => m.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (isExist)
            {
                ModelState.AddModelError("Name","Bu category movcuddur");
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
