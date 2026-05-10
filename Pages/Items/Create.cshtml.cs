using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM_3315_Final_Project.Models;

namespace CIDM_3315_Final_Project.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly CIDM_3315_Final_Project.Models.AppDbContext _context;

        public CreateModel(CIDM_3315_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RarityID"] = new SelectList(_context.Rarities, "RarityID", "Name");
        ViewData["TypeID"] = new SelectList(_context.Types, "TypeID", "Name");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
