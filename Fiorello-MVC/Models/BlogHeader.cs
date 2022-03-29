using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class BlogHeader:BaseEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
    }
}
