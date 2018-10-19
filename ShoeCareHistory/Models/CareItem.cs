using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class CareItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CareCategory CareCategory { get; set; }
        public CareBrand CareBrand { get; set; }

        //public CareItem(int id, string name, CareCategory category, CareBrand cb)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.CareCategory = category;
        //    this.CareBrand = cb;
        //}
    }

    public enum CareCategory
    {
        Brush,
        Cream,
        Oil,
        Cleaner
    }
}
