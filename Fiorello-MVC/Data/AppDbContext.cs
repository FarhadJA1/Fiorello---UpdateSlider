using Fiorello_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderDetail> SliderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Valentine> ValentineDetails { get; set; }
        public DbSet<ExpertsText> ExpertsTexts { get; set; }
        public DbSet<Experts> Experts { get; set; }
        public DbSet<BlogHeader> BlogHeaders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Testimone> Testimones { get; set; }
        public DbSet<Instagram> Instagrams { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
