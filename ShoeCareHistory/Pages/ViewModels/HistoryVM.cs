using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.ViewModels
{
    public class HistoryVM : History
    {
        public string ShoeName { get; set; }

        public IList<string> CareItemNames { get; set; }

        public SelectList ShoeList { get; set; }

        public SelectList CareItemList { get; set; }
    }
}
