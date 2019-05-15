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
    public class DetailsModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public DetailsModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public History History { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            History = await _context.History
                .Include(h => h.Shoe).FirstOrDefaultAsync(m => m.Id == id);

            if (History == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
