using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;
using ShoeCareHistory.Utility;

namespace ShoeCareHistory.Pages
{
    public class InOutModel : PageModel
    {
        private readonly Models.ShoeCareHistoryContext _context;

        private readonly string[] values = new string[]
            {
                "All",
                "CareBrand",
                "CareItem",
                "History",
                "Shoe",
                "ShoeMaker",
            };

        [BindProperty]
        public string SelectedValue { get; set; }

        public IEnumerable<SelectListItem> SelectListItems { get; set; }

        public InOutModel(ShoeCareHistoryContext context)
        {
            _context = context;
            SelectListItems = new InOutUtility(values).CreateSelector();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostOutputAsync()
        {
            var io = new IOUtility();

            switch (SelectedValue)
            {
                case "CareBrand":
                    await io.OutputJsonAsync(_context.CareBrand.ToList());
                    break;
                case "CareItem":
                    await io.OutputJsonAsync(_context.CareItem.ToList());
                    break;
                case "Shoe":
                    await io.OutputJsonAsync(_context.Shoe.ToList());
                    break;
                case "ShoeMaker":
                    await io.OutputJsonAsync(_context.ShoeMaker.ToList());
                    break;
                case "History":
                    await io.OutputJsonAsync(_context.History.ToList());
                    break;
                case "All":
                    var tasks = new List<Task>()
                    {
                        io.OutputJsonAsync(_context.CareBrand.ToList()),
                        io.OutputJsonAsync(_context.CareItem.ToList()),
                        io.OutputJsonAsync(_context.Shoe.ToList()),
                        io.OutputJsonAsync(_context.ShoeMaker.ToList()),
                        io.OutputJsonAsync(_context.History.ToList()),
                    };
                    await Task.WhenAll(tasks);
                    break;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostInputAsync()
        {
            using (var tran = _context.Database.BeginTransaction())

                try
                {
                    switch (SelectedValue)
                    {
                        case "CareBrand":
                            await new CareBrandUtility(_context).CreateDataAsync();
                            break;
                        case "CareItem":
                            await new CareItemUtility(_context).CreateDataAsync();
                            break;
                        case "Shoe":
                            await new ShoeUtility(_context).CreateDataAsync();
                            break;
                        case "ShoeMaker":
                            await new ShoeMakerUtility(_context).CreateDataAsync();
                            break;
                        case "History":
                            await new HistoryUtility(_context).CreateDataAsync();
                            break;
                        case "All":
                            var tasks = new List<Task>()
                            {
                                new CareBrandUtility(_context).CreateDataAsync(),
                                new CareItemUtility(_context).CreateDataAsync(),
                                new ShoeUtility(_context).CreateDataAsync(),
                                new ShoeMakerUtility(_context).CreateDataAsync(),
                                new HistoryUtility(_context).CreateDataAsync(),
                            };
                            await Task.WhenAll(tasks);
                            break;
                    }

                    await tran.CommitAsync();
                }
                catch (Exception ex)
                {
                    await tran.RollbackAsync();
                }

            return Page();
        }
    }
}