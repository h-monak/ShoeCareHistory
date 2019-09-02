using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.ViewModels
{
    public class CareItemVM : CareItem
    {
        public SelectList CareCategoryList { get; set; }

        public SelectList CareBrandList { get; set; }
    }
}
