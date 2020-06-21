using Microsoft.EntityFrameworkCore;
using ScoutsMealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Data
{
    public class MenuService
    {
        private ApplicationDbContext context;

        public MenuService(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        public async Task<List<Menu>> GetMenusAsync()
        {
            return await context.Menus.ToListAsync<Menu>();
        }
    }
}
