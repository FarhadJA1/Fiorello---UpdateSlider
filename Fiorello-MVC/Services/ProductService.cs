using Fiorello_MVC.Data;
using Fiorello_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProducts(int take)
        {
            List<Product> products = await _context.Products
               .Include(m => m.Category)
               .Include(m => m.Images)
               .Take(take)
               .ToListAsync();
            return products;
        }
    }
}
