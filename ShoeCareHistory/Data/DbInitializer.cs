using ShoeCareHistory.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Data
{
    public class DbInitializer
    {
        /// <summary>
        /// 初期データ作成
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ShoeCareHistoryContext context)
        {
            var redwing = new ShoeMaker()
            {
                Id = 1, Name = "RedWing", Country = "United States", Established = 1906
            };
            var whites = new ShoeMaker()
            {
                Id = 2, Name = "White's Boots", Country = "United States", Established = 1901
            };
            var trickers = new ShoeMaker()
            {
                Id = 3, Name = "Tricker's", Country = "United Kingdom", Established = 1950
            };

            // ShoeMaker
            if (!context.ShoeMaker.Any())
                {
                    var shoemakers = new ShoeMaker[]
                    {
                        redwing,
                        whites,
                        trickers
                    };
                    foreach (ShoeMaker sm in shoemakers) context.ShoeMaker.Add(sm);
                }

            // Shoes
            if(!context.Shoe.Any())
            {
                // CSVファイル名直接指定して読み込む
                var shoeList = CsvRead.ReadFile("");

                ShoeMaker smkr = null;

                foreach(int i in shoeList.Keys)
                {
                    var data = shoeList[i];

                    // メーカー名判定
                    switch(data[7])
                    {
                        case "RedWing" :
                            smkr = redwing;
                            break;
                        case "White's":
                            smkr = whites;
                            break;
                        default :
                            smkr = null;
                            break;
                    }

                    context.Shoe.Add(new Shoe()
                    {
                        Id = int.Parse(data[0]), Name = data[1], Code = data[2], Leather = data[3],
                        Color = data[4], ProductName = data[5], ProductionDate = DateTime.Parse(data[6]),
                        PurchaseDate = DateTime.Parse(data[7]), ShoeMaker = smkr
                    });
                }

                //for(int i = 0; i < shoeList.Count; i++)
                //{

                //}
                var shoes = new Shoe[]
                {
                    //new Shoe(1, "", "", "", "", "", DateTime.Now, DateTime.MaxValue, redwing)

                };
                foreach (Shoe s in shoes) context.Shoe.Add(s);
            }

            // CareBrand
            if (!context.CareBrand.Any())
            {
                var carebrands = new CareBrand[]
                {

                };
                foreach (CareBrand cb in carebrands) context.CareBrand.Add(cb);
            }

            // CareItem
            if (!context.CareItem.Any())
            {
                var careitems = new CareItem[]
                    {

                    };
                foreach (CareItem ci in careitems) context.CareItem.Add(ci);
            }

            // History
            if (!context.History.Any())
            {
                var histories = new History[]
                {


                };
                foreach (History h in histories) context.History.Add(h);
            }

            // 変更をDBに反映
            context.SaveChanges();

        }
    }
}
