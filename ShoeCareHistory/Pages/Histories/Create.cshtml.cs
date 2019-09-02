using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Pages.Histories
{
    public class CreateModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public CreateModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ShoeId"] = new SelectList(_context.Shoe, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public History History { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.History.Add(History);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}