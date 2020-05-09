using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Models
{
    public class Equipment
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<RecipeEquipment> RecipeEquipments { get; set; }
    }
}
