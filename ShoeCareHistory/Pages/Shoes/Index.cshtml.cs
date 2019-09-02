using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Pages.Shoes
{
    public class IndexModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IndexModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IList<Shoe> Shoe { get;set; }

        public async Task OnGetAsync()
        {
            Shoe = await _context.Shoe
                .Include(m => m.ShoeMaker)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
