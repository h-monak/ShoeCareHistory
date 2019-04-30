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

        //public ShoeMaker(int id, string name, string country, int est_year)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Country = country;
        //    this.Established = est_year;
        //}
    }
}
