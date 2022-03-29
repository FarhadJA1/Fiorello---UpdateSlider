using Fiorello_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderDetail Detail { get; set; }
        public List<Category> Categories { get; internal set; }
        public List<Product> Products { get; set; }
        public Valentine ValentineDetails { get; set; }
        public ExpertsText ExpertsText { get; set; }
        public List<Experts> Experts { get; set; }
        public BlogHeader BlogHeader { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Testimone> Testimonials { get; set; }
        public List<Instagram> Instagrams { get; set; }
    }
}
