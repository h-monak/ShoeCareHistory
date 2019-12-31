using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Pages.CareItems
{
    public class CreateModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IEnumerable<SelectListItem> SelectList { get; set; }

        public CreateModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
            SelectList = new Utility.CareBrandUtility(_context).CreateSelector();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CareItem CareItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CareItem.Add(CareItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}