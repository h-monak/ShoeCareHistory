using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        public int ShoeId { get; set; }

        public int CareItemId { get; set; }

        /// <summary>
        /// 手入れ日
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CareDate { get; set; }

        /// <summary>
        /// 封印日
        /// </summary>
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SealDate { get; set; }

        [DataType(DataType.Text)]
        public string Detail { get; set; }

        public Shoe Shoe { get; set; }

        public ICollection<CareItem> CareItems { get; set; }

        //public History(int id, DateTime caredate, string detail, Shoe shoe, CareItem[] careitems)
        //{
        //    this.Id = id;
        //    this.CareDate = caredate;
        //    this.Detail = detail;
        //    this.Shoe = shoe;
        //    foreach(CareItem ci in careitems) this.CareItems.Add(ci);
        //}
    }
}
