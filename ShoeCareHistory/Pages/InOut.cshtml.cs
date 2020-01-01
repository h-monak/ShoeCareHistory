using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoeCareHistory.Models;
using ShoeCareHistory.Utility;

namespace ShoeCareHistory.Pages
{
    public class InOutModel : PageModel
    {
        private readonly Models.ShoeCareHistoryContext _context;

        public InOutModel(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostOutputAsync()
        {
            var io = new IOUtility();
            var data = _context.Shoe.ToList();
            await io.OutputJsonAsync(data);

            return Page();
        }

        public async Task<IActionResult> OnPostInputAsync()
        {
            return Page();
        }
    }
}