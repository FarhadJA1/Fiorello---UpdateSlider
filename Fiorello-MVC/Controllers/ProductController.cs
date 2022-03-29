using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products
                .Include(m => m.Category)
                .Include(m => m.Images)
                .ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> LoadMore()
        {
            List<Product> products = await _context.Products
                .Include(m => m.Category)
                .Include(m => m.Images)
                .Take(4)
                .ToListAsync();
                
                
            return Json(products);
        }
    }
}
