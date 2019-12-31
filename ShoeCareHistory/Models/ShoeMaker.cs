using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class ShoeMaker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        [Display(Name = "Est.")]
        public int Established { get; set; }

        public List<Shoe> Shoes { get; set; }
    }
}
