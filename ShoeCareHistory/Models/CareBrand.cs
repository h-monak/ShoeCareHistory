using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class CareBrand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public CareBrand(int id, string name)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //}
    }
}
