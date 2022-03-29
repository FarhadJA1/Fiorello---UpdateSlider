using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class Valentine:BaseEntity
    {
        public string Image { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string FirstOption { get; set; }
        public string SecondOption { get; set; }
        public string ThirdOption { get; set; }

    }
}
