using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime CareDate { get; set; }
        public string Detail { get; set; }
        public Shoe Shoe { get; set; }
        public ICollection<CareItem> CareItems { get; set; }

        //public History(int id, DateTime caredate, string detail, Shoe shoe, CareItem[] careitems)
        //{
        //    this.Id = id;
        //    this.CareDate = caredate;
        //    this.Detail = detail;
        //    this.Shoe = shoe;
        //    foreach(CareItem ci in careitems) this.CareItems.Add(ci);
        //}
    }
}
