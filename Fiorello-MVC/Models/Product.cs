using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class Product:BaseEntity
    {
        
        public string Name { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category  Category { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
