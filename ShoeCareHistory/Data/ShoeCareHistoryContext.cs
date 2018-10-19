using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Models
{
    public class ShoeCareHistoryContext : DbContext
    {
        public ShoeCareHistoryContext (DbContextOptions<ShoeCareHistoryContext> options)
            : base(options)
        {
        }

        public DbSet<ShoeCareHistory.Models.CareBrand> CareBrand { get; set; }

        public DbSet<ShoeCareHistory.Models.CareItem> CareItem { get; set; }

        public DbSet<ShoeCareHistory.Models.ShoeMaker> ShoeMaker { get; set; }

        public DbSet<ShoeCareHistory.Models.Shoe> Shoe { get; set; }

        public DbSet<ShoeCareHistory.Models.History> History { get; set; }
    }
}
