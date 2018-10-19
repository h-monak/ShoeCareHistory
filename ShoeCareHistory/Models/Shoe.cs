using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public string Leather { get; set; }
        public string Color { get; set; }

        [Display(Name = "Production Date")]
        [DataType(DataType.DateTime)]
        public DateTime ProductionDate { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }

        public ShoeMaker ShoeMaker { get; set; }

        //public Shoe(int id, string name, string code, string pname, string leather, string color, DateTime prdate, DateTime pudate, ShoeMaker sm)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Code = code;
        //    this.ProductName = pname;
        //    this.Leather = leather;
        //    this.Color = color;
        //    this.ProductionDate = prdate;
        //    this.PurchaseDate = pudate;
        //    this.ShoeMaker = sm;
        //}
    }
}
