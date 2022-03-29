using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello_MVC.Models
{
    public class SliderDetail
    {
        public int Id { get; set; }
        public string Header { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public static implicit operator List<object>(SliderDetail v)
        {
            throw new NotImplementedException();
        }
    }
}
