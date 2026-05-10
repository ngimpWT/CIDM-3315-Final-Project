using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3315_Final_Project.Models;

namespace CIDM_3315_Final_Project.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly CIDM_3315_Final_Project.Models.AppDbContext _context;

        public IndexModel(CIDM_3315_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Item = await _context.Items
                .Include(i => i.Rarity)
                .Include(i => i.Type).ToListAsync();
        }
    }
}
