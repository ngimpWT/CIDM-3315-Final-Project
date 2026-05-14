using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM_3315_Final_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace CIDM_3315_Final_Project.Pages
{
    public class AddRarityModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AddRarityModel> _logger;

        [BindProperty]
        public Rarity Rarity { get; set; } = default!;

        public AddRarityModel(AppDbContext context, ILogger<AddRarityModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
    {

    }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var e in allErrors)
                {
                    _logger.LogError($"Error: {e.ErrorMessage}");
                }
                return Page();
            }

            _context.Rarities.Add(Rarity);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}