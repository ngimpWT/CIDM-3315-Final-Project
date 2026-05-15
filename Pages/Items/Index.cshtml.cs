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

        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;
        public int TotalPages {get; set;}

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;

        [BindProperty(SupportsGet =  true)]
        public string CurrentSearch {get; set;} = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Items.Include(i => i.Rarity).Include(i => i.Type).Select(s => s);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(i => i.Name.ToUpper().Contains(CurrentSearch.ToUpper()));
            }

            switch (CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(i => i.Name);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(i => i.Name);
                    break;
            }
            TotalPages = (int)Math.Ceiling(_context.Items.Count() / (double)PageSize);
    
            Item = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync(); 
        }
    }
}
