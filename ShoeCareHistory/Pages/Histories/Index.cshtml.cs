using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Pages.Histories
{
    public class IndexModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IndexModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IList<History> History { get;set; }

        public async Task OnGetAsync()
        {
            History = await _context.History
                .Include(h => h.Shoe).ToListAsync();
        }
    }
}
