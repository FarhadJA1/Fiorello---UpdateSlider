using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class Blog:BaseEntity
    {
        public string Image { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }

    }
}
