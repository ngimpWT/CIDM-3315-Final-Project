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
    public class DeleteRarityModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteRarityModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rarity Rarity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rarity = await _context.Rarities.FirstOrDefaultAsync(m => m.RarityID == id);

            if (rarity is not null)
            {
                Rarity = rarity;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rarity = await _context.Rarities.FindAsync(id);
            if (rarity != null)
            {
                Rarity = rarity;
                _context.Rarities.Remove(Rarity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
