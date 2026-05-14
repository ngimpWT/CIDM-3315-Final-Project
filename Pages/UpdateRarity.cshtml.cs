using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CIDM_3315_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3315_Final_Project.Pages;

public class UpdateRarityModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<UpdateRarityModel> _logger;

    [BindProperty]
    public Rarity Rarity {get; set;} = default!;

    public UpdateRarityModel(AppDbContext context, ILogger<UpdateRarityModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var rarity = _context.Rarities.Find(id);
        if (rarity == null)
        {
            return NotFound();
        }
        else
        {
            Rarity = rarity;
        }
        return Page();
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

        _context.Attach(Rarity).State = EntityState.Modified;
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}