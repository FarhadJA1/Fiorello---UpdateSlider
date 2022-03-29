using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class Category:BaseEntity
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
