using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class CareBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CareBrand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
