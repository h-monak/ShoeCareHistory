using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;
using ShoeCareHistory.ViewModels;

namespace ShoeCareHistory.Pages.Histories
{
    public class IndexModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IndexModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IList<HistoryVM> HistoryVM { get; set; }

        public async Task OnGetAsync()
        {
            HistoryVM = await _context.History
                .Select(s => new HistoryVM()
                {
                    Id = s.Id,
                    ShoeName = s.Shoe.Name,
                    Detail = s.Detail,
                    CareDate = s.CareDate,
                    CareItemNames = s.CareItems.Select(i => i.Name).ToList()
                }).ToListAsync();
        }
    }
}
