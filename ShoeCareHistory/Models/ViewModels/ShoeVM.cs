using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.ViewModels
{
    public class ShoeVM : Shoe
    {
        public SelectList ShoeMakerList { get; set; }
        public string ShoeMakerName { get; internal set; }
    }
}
