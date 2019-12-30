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

        public EditModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
        }

        //[BindProperty]
        //public ShoeVM ShoeVM { get; set; }
        public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shoe = await _context.Shoe
                .Where(w => w.Id == id)
                .Include(m => m.ShoeMaker)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            //.Include(m => m.ShoeMaker)
            //.AsNoTracking()
            //.Select(s => new ShoeVM() {
            //    Id = s.Id,
            //    Name = s.Name,
            //    Code = s.Code,
            //    Leather = s.Leather,
            //    Color = s.Color,
            //    Material = s.Material,
            //    IsSold = s.IsSold,
            //    ProductName = s.ProductName,
            //    ProductionDate = s.ProductionDate,
            //    PurchaseDate = s.PurchaseDate,
            //    BreakInDate = s.BreakInDate,
            //    ShoeMakerName = s.ShoeMaker.Name
            //}).FirstOrDefaultAsync();

            //ShoeVM.ShoeMakerList = new SelectList(_context.ShoeMaker, "", "", _context.ShoeMaker);

            //ViewData["ShoeMakerId"] = new SelectList(_context.ShoeMaker, "ShoeMakerId", "ShoeMakerName", ShoeVM.ShoeMaker.Id);

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
