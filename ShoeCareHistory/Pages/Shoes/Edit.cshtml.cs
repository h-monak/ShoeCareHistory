using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;
using ShoeCareHistory.ViewModels;

namespace ShoeCareHistory.Pages.Shoes
{
    public class EditModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IEnumerable<SelectListItem> ShoeMakerList { get; set; }

        public EditModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _context.Shoe
                .Where(w => w.Id == id)
                .Include(m => m.ShoeMaker)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            ShoeMakerList = _context.ShoeMaker
                .Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Name,
                });

            Shoe = await task;

            ShoeMakerList.Where(x => x.Value == Shoe.ShoeMakerId.ToString())
                .FirstOrDefault()
                .Selected = true;

            if (Shoe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shoe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoeExists(Shoe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShoeExists(int? id)
        {
            return _context.Shoe.Any(e => e.Id == id);
        }
    }
}
