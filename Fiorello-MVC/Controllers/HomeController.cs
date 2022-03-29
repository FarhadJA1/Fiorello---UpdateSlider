using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Fiorello_MVC.Services;
using Fiorello_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        private readonly ProductService _productService;
        public HomeController(AppDbContext context, LayoutService layoutService, ProductService productService)
        {
            _context = context;
            _layoutService = layoutService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> settings = _layoutService.GetSettings();

            int take = int.Parse(settings["HomeTake"]);

            List<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderDetail detail = await _context.SliderDetails.FirstOrDefaultAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
           
            ExpertsText expertsText = await _context.ExpertsTexts.FirstOrDefaultAsync();
            List<Experts> experts = await _context.Experts.ToListAsync();
            BlogHeader blogHeader = await _context.BlogHeaders.FirstOrDefaultAsync();
            List<Blog> blogs = await _context.Blogs.ToListAsync();
            List<Testimone> testimones = await _context.Testimones.ToListAsync();
            List<Instagram> instagrams = await _context.Instagrams.ToListAsync();
            List<Product> products = await _productService.GetProducts(take);
            HomeVM homeVM = new HomeVM()
            {
                Sliders = sliders,
                Detail = detail,
                Categories = categories,
                Products = products,
                ExpertsText = expertsText,
                Experts=experts,
                BlogHeader=blogHeader,
                Blogs=blogs,
                Testimonials=testimones,
                Instagrams=instagrams
                
            };
            return View(homeVM);
        }
    }
}
