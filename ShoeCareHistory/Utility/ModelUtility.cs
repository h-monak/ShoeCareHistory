using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Utility
{
    public abstract class ModelUtility
    {
        public abstract IEnumerable<SelectListItem> CreateSelector();
    }

    public class CareItemUtility : ModelUtility
    {
        private readonly ShoeCareHistoryContext _context;

        public CareItemUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public override IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.CareItem
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }
    }

    public class CareBrandUtility : ModelUtility
    {
        private readonly ShoeCareHistoryContext _context;

        public CareBrandUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public override IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.CareBrand
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }
    }

    public class ShoeMakerUtility : ModelUtility
    {
        private readonly ShoeCareHistoryContext _context;

        public ShoeMakerUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public override IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.ShoeMaker
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }
    }

    public class ShoeUtility : ModelUtility
    {
        private readonly ShoeCareHistoryContext _context;

        public ShoeUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public override IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.Shoe
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }
    }

    public class CareCategoryUtility : ModelUtility
    {
        public override IEnumerable<SelectListItem> CreateSelector()
        {
            var values = Enum.GetValues(typeof(CareCategory));
            var selectListItems = new List<SelectListItem>();

            foreach(var value in values)
            {
                selectListItems.Add(new SelectListItem(Enum.GetName(typeof(CareCategory), value) , value.ToString()));
            }
            return selectListItems;
        }
    }
}
