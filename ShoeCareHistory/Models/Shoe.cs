using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class Shoe
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string Leather { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        [Display(Name = "Production Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProductionDate { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Break In Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BreakInDate { get; set; }

        public bool IsSold { get; set; }

        public int? ShoeMakerId { get; set; }

        public ShoeMaker ShoeMaker { get; set; }
    }
}
