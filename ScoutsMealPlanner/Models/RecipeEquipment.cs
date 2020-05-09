using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Models
{
    public class RecipeEquipment
    {
        public Guid EquipmentID { get; set; }
        public Guid RecipeID { get; set; }
        public Equipment Equipment { get; set; }
        public Recipe Recipe { get; set; }
    }
}
