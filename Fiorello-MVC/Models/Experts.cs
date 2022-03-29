using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class Experts:BaseEntity
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }

        public static implicit operator Experts(List<Experts> v)
        {
            throw new NotImplementedException();
        }
    }
}
