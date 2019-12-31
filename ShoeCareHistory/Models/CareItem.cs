using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class CareItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }

        public int CareBrandId { get; set; }

        [Range(0, 4)]
        public int CareCategory { get; set; }

        public CareBrand CareBrand { get; set; }
    }

    public enum CareCategory
    {
        Extra,
        Brush,
        Cream,
        Oil,
        Cleaner
    }
}
