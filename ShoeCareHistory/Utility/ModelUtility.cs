using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Utility
{
    public interface IModelUtility
    {
        public IEnumerable<SelectListItem> CreateSelector();
    }

    public interface IDBCreater
    {
        public Task CreateDataAsync();
    }

    public class CareItemUtility : IModelUtility, IDBCreater
    {
        private readonly ShoeCareHistoryContext _context;

        public CareItemUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.CareItem
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }

        public async Task CreateDataAsync()
        {
            var io = new IOUtility();
            var ret = io.InputJsonAsync<CareItem>();
            _context.CareItem.RemoveRange(_context.CareItem);
            await _context.CareItem.AddRangeAsync(await ret);
        }
    }

    public class CareBrandUtility : IModelUtility, IDBCreater
    {
        private readonly ShoeCareHistoryContext _context;

        public CareBrandUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.CareBrand
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }

        public async Task CreateDataAsync()
        {
            var io = new IOUtility();
            var ret = io.InputJsonAsync<CareBrand>();
            _context.CareBrand.RemoveRange(_context.CareBrand);
            await _context.CareBrand.AddRangeAsync(await ret);
        }
    }

    public class ShoeMakerUtility : IModelUtility, IDBCreater
    {
        private readonly ShoeCareHistoryContext _context;

        public ShoeMakerUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.ShoeMaker
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }

        public async Task CreateDataAsync()
        {
            var io = new IOUtility();
            var ret = io.InputJsonAsync<ShoeMaker>();
            _context.ShoeMaker.RemoveRange(_context.ShoeMaker);
            await _context.ShoeMaker.AddRangeAsync(await ret);
        }
    }

    public class ShoeUtility : IModelUtility, IDBCreater
    {
        private readonly ShoeCareHistoryContext _context;

        public ShoeUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> CreateSelector()
        {
            return _context.Shoe
                        .AsNoTracking()
                        .Select(x => new SelectListItem()
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name
                        });
        }

        public async Task CreateDataAsync()
        {
            var io = new IOUtility();
            var ret = io.InputJsonAsync<Shoe>();
            _context.Shoe.RemoveRange(_context.Shoe);
            await _context.Shoe.AddRangeAsync(await ret);
        }
    }

    public class CareCategoryUtility : IModelUtility
    {
        public IEnumerable<SelectListItem> CreateSelector()
        {
            var values = Enum.GetValues(typeof(CareCategory));
            var selectListItems = new List<SelectListItem>();

            foreach (var value in values)
            {
                selectListItems.Add(new SelectListItem(Enum.GetName(typeof(CareCategory), value), value.ToString()));
            }
            return selectListItems;
        }
    }

    public class HistoryUtility : IDBCreater
    {
        private readonly ShoeCareHistoryContext _context;

        public HistoryUtility(ShoeCareHistoryContext context)
        {
            _context = context;
        }

        public async Task CreateDataAsync()
        {
            var io = new IOUtility();
            var ret = io.InputJsonAsync<History>();
            _context.History.RemoveRange(_context.History);
            await _context.History.AddRangeAsync(await ret);
        }
    }

    public class InOutUtility : IModelUtility
    {
        private readonly string[] _values;

        public InOutUtility(string[] values)
        {
            _values = values;
        }

        public IEnumerable<SelectListItem> CreateSelector()
        {
            var selectListItems = new List<SelectListItem>();

            foreach (var value in _values)
            {
                selectListItems.Add(new SelectListItem(value, value));
            }
            return selectListItems;
        }
    }
}
