using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Pages.Shoes
{
    public class CreateModel : PageModel
    {
        private readonly ShoeCareHistory.Models.ShoeCareHistoryContext _context;

        public IEnumerable<SelectListItem> ShoeMakerList { get; set; }

        public CreateModel(ShoeCareHistory.Models.ShoeCareHistoryContext context)
        {
            _context = context;
            ShoeMakerList = _context.ShoeMaker.Select(x => new SelectListItem() 
            { 
                Value = x.Id.ToString(), 
                Text = x.Name 
            });
        }

        public IActionResult OnGet()
        {
            //var shoeMakers = _context.ShoeMaker.Select(x => new
            //{
            //    x.Id,
            //    x.Name,
            //});

            //var shoeMakerList = new List<SelectListItem>();
            //foreach (var sm in shoeMakers)
            //{
            //    shoeMakerList.Add(new SelectListItem() { Value = sm.Id.ToString(), Text = sm.Name });
            //}
            //ShoeMakerList = shoeMakerList;
            return Page();
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //var shoeMaker = ShoeMakerList.FirstOrDefault(x => x.Selected);
            //Shoe.ShoeMaker.Id = int.Parse(shoeMaker.Value);
            //Shoe.ShoeMaker.Name = shoeMaker.Text;

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