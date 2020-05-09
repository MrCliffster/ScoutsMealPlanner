using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Models
{
    public class Camp
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
