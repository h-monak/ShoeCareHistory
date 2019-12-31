using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Pages.Shoes
{
    public class CreateModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IEnumerable<SelectListItem> ShoeMakerList { get; set; }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public CreateModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
            ShoeMakerList = new Utility.ShoeMakerUtility(_context).CreateSelector();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shoe.Add(Shoe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}