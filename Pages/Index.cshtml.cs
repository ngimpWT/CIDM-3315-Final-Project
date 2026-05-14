using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3315_Final_Project.Models;

namespace CIDM_3315_Final_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CIDM_3315_Final_Project.Models.AppDbContext _context;

        public IndexModel(CIDM_3315_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Rarity> Rarity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Rarity = await _context.Rarities.Include(i => i.Items).ThenInclude(t => t.Type).ToListAsync();
        }
    }
}