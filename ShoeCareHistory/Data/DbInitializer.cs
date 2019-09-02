using Microsoft.EntityFrameworkCore;
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
            context.Database.OpenConnection();

            var redwing = new ShoeMaker()
            {
                Id = 1,
                Name = "RedWing",
                Country = "United States",
                Established = 1905
            };
            var whites = new ShoeMaker()
            {
                Id = 2,
                Name = "White's Boots",
                Country = "United States",
                Established = 1850
            };
            var trickers = new ShoeMaker()
            {
                Id = 3,
                Name = "Tricker's",
                Country = "United Kingdom",
                Established = 1829
            };
            var wolverine = new ShoeMaker()
            {
                Id = 4,
                Name = "Wolverine",
                Country = "United States",
                Established = 1883
            };
            var regal = new ShoeMaker()
            {
                Id = 5,
                Name = "Regal",
                Country = "United States",
                Established = 1880
            };
            var jalan = new ShoeMaker()
            {
                Id = 6,
                Name = "Jalan Sriwijaya",
                Country = "Indonesia",
                Established = 1919
            };
            var danner = new ShoeMaker()
            {
                Id = 7,
                Name = "Danner",
                Country = "United States",
                Established = 1900
            };
            var other = new ShoeMaker()
            {
                Id = 8,
                Name = "Other",
                Country = "None",
                Established = 0
            };

            // ShoeMaker
            if (!context.ShoeMaker.Any())
            {
                var shoemakers = new ShoeMaker[]
                {
                    redwing,
                    whites,
                    trickers,
                    wolverine,
                    regal,
                    jalan,
                    other
                };
                foreach (ShoeMaker sm in shoemakers) context.ShoeMaker.Add(sm);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ShoeMaker ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ShoeMaker OFF");
            }

            // Shoes
            if (!context.Shoe.Any())
            {
                var shoes = new Shoe[]
                {
                    new Shoe(){ Id = 1,  ShoeMaker = redwing, Name = "8166", Code = "8166", ProductName = "CLASSIC WORKS ROUND TOE", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-12-01"), BreakInDate = DateTime.Parse("13-12-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 2,  ShoeMaker = redwing, Name = "8165", Code = "8165", ProductName = "CLASSIC WORKS ROUND TOE", Leather = "", Color = "BLACK CHROME", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-01-01"), BreakInDate = DateTime.Parse("13-01-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 3,  ShoeMaker = redwing, Name = "875", Code = "875", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO REGACY", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-02-01"), BreakInDate = DateTime.Parse("14-02-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 4,  ShoeMaker = redwing, Name = "8112", Code = "8112", ProductName = "IRON RANGER", Leather = "", Color = "ORO IGINAL", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-11-01"), BreakInDate = DateTime.Parse("13-11-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 5,  ShoeMaker = redwing, Name = "2907", Code = "2907", ProductName = "LIINEMAN", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-10-01"), BreakInDate = DateTime.Parse("14-10-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 6,  ShoeMaker = redwing, Name = "8271", Code = "8271", ProductName = "ENGENEER", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-09-27"), BreakInDate = DateTime.Parse("15-09-27"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 7,  ShoeMaker = redwing, Name = "9011", Code = "9011", ProductName = "BECKMAN", Leather = "", Color = "BLACK CHERRY FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-08-01"), BreakInDate = DateTime.Parse("13-08-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 8,  ShoeMaker = redwing, Name = "9013", Code = "9013", ProductName = "BECKMAN", Leather = "", Color = "CHESTNUT FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-05-01"), BreakInDate = DateTime.Parse("14-05-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 9,  ShoeMaker = redwing, Name = "9024", Code = "9024", ProductName = "BECKMAN CHUKKA", Leather = "", Color = "BLACK FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-10-22"), BreakInDate = DateTime.Parse("15-10-22"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 10,  ShoeMaker = wolverine, Name = "1000MILE", Code = "1000MILE", ProductName = "1000MILE", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-01-01"), BreakInDate = DateTime.Parse("14-01-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 11,  ShoeMaker = wolverine, Name = "W05342", Code = "W05342", ProductName = "1000MILE ADDISON", Leather = "", Color = "BROWN CHROME EXCEL", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-10-01"), BreakInDate = DateTime.Parse("13-10-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 12,  ShoeMaker = whites, Name = "BOUNTY HUNTER", Code = "BOUNTY HUNTER", ProductName = "BOUNTY HUNTER", Leather = "", Color = "RED DOG SMOOTH", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-01-14"), BreakInDate = DateTime.Parse("16-01-14"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 13,  ShoeMaker = whites, Name = "SEMI DRESS", Code = "SEMI DRESS", ProductName = "SEMI DRESS", Leather = "", Color = "SIENNA WATER BUFFALO", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-04-20"), BreakInDate = DateTime.Parse("16-04-20"), IsSold = false, Material = "WATER BUFFALO"},
                    new Shoe(){ Id = 14,  ShoeMaker = regal, Name = "PLANE TOE", Code = "", ProductName = "PLANE TOE", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("12-07-01"), BreakInDate = DateTime.Parse("12-07-01"), IsSold = false, Material = "ガラス"},
                    new Shoe(){ Id = 15,  ShoeMaker = regal, Name = "STRAIGHT CHIP", Code = "", ProductName = "STRAIGHT CHIP", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-03-01"), BreakInDate = DateTime.Parse("15-03-01"), IsSold = false, Material = "合皮"},
                    new Shoe(){ Id = 16,  ShoeMaker = regal, Name = "ローファー", Code = "", ProductName = "ローファー", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("03-03-01"), BreakInDate = DateTime.Parse("03-03-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 17,  ShoeMaker = other, Name = "STRAIGHT CHIP", Code = "", ProductName = "STRAIGHT CHIP", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-02-01"), BreakInDate = DateTime.Parse("15-02-01"), IsSold = false, Material = "ステアハイド"},
                    new Shoe(){ Id = 18,  ShoeMaker = jalan, Name = "BLOGUE", Code = "", ProductName = "BLOGUE", Leather = "", Color = "BROWN", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-06-01"), BreakInDate = DateTime.Parse("15-06-01"), IsSold = false, Material = "CURF"},
                    new Shoe(){ Id = 19,  ShoeMaker = jalan, Name = "PLANE TOE", Code = "", ProductName = "PLANE TOE", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-01-22"), BreakInDate = DateTime.Parse("16-01-22"), IsSold = false, Material = "CURF"},
                    new Shoe(){ Id = 20,  ShoeMaker = redwing, Name = "877", Code = "877", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO REGACY", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-11-12"), BreakInDate = DateTime.Parse("16-11-19"), IsSold = true, Material = "COWHIDE"},
                    new Shoe(){ Id = 21,  ShoeMaker = redwing, Name = "9046", Code = "9046", ProductName = "BECKMAN OXFORD", Leather = "", Color = "TEAK FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-03-02"), BreakInDate = DateTime.Parse("17-04-03"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 22,  ShoeMaker = redwing, Name = "9087", Code = "9087", ProductName = "BLUCHER OXFORD", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-04-25"), BreakInDate = DateTime.Parse("17-05-08"), IsSold = false, Material = "HEFAHIDE"},
                    new Shoe(){ Id = 23,  ShoeMaker = whites, Name = "SEMI DRESS", Code = "SEMI DRESS", ProductName = "SEMI DRESS", Leather = "", Color = "BROWN DRESS" , ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-06-29"), BreakInDate = DateTime.Parse("17-07-01"), IsSold = false, Material = "SEMI DRESS"},
                    new Shoe(){ Id = 24,  ShoeMaker = redwing, Name = "9032", Code = "9032", ProductName = "BECKMAN CHUKKA", Leather = "", Color = "BLACK CHERRY FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-08-11"), BreakInDate = DateTime.Parse("17-08-11"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 25,  ShoeMaker = trickers, Name = "M6087", Code = "M6087", ProductName = "ETHAN MONKEY BOOTS", Leather = "", Color = "ACORN ANTIQUE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-10-14"), BreakInDate = DateTime.Parse("17-10-27"), IsSold = false, Material = "CURF"},
                    new Shoe(){ Id = 26,  ShoeMaker = whites, Name = "BOUNTY HUNTER", Code = "BOUNTY HUNTER", ProductName = "BOUNTY HUNTER", Leather = "", Color = "BROWN DRESS", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-10-29"), BreakInDate = DateTime.Parse("17-11-03"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 27,  ShoeMaker = redwing, Name = "2966", Code = "2966", ProductName = "ENGENEER", Leather = "", Color = "BLACK CLONEDICE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-11-03"), BreakInDate = DateTime.Parse("17-11-04"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 28,  ShoeMaker = redwing, Name = "9079", Code = "9079", ProductName = "CHELSEA BOOTS", Leather = "", Color = "BLACK FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-12-17"), BreakInDate = DateTime.Parse("17-12-17"), IsSold = false,  Material = "COWHIDE"},
                    new Shoe(){ Id = 29,  ShoeMaker = redwing, Name = "877", Code = "877", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO IGINAL", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("18-02-17"), BreakInDate = DateTime.Parse("18-02-17"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 30,  ShoeMaker = redwing, Name = "899", Code = "899", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("18-02-24"), BreakInDate = DateTime.Parse("18-02-24"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ Id = 31,  ShoeMaker = danner, Name = "Danner Light", Code = "30457", ProductName = "Danner Light", Leather = "", Color = "CEDAR BROWN", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("18-12-20"), BreakInDate = DateTime.Parse("18-12-20"), IsSold = false, Material = "COWHIDE"},
                };
                foreach (Shoe s in shoes) context.Shoe.Add(s);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Shoe ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Shoe OFF");
            }

            // CareBrand
            var redWing = new CareBrand() { Id = 1, Name = "RedWing" };
            var mowbray = new CareBrand() { Id = 2, Name = "M.Mowbray" };
            var hirano = new CareBrand() { Id = 3, Name = "Hirano" };
            var beckman = new CareBrand() { Id = 4, Name = "Beckman" };
            var renapur = new CareBrand() { Id = 5, Name = "Renapur" };
            var lexol = new CareBrand() { Id = 6, Name = "Lexol" };
            var uw = new CareBrand() { Id = 99, Name = "Union Works" };

            if (!context.CareBrand.Any())
            {
                var carebrands = new CareBrand[]
                {
                    redWing,
                    mowbray,
                    hirano,
                    beckman,
                    renapur,
                    lexol,
                    uw
                };
                foreach (CareBrand cb in carebrands) context.CareBrand.Add(cb);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareBrand ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareBrand OFF");
            }

            // CareItem
            if (!context.CareItem.Any())
            {
                var careitems = new CareItem[]
                {
                    new CareItem(){ Id = 1, Name= "Leather Conditioner", CareCategory = CareCategory.Oil, CareBrand = redWing },
                    new CareItem(){ Id = 2, Name = "Boot Cream",  CareCategory = CareCategory.Cream, CareBrand = redWing, Color = "Oro Russet" },
                    new CareItem(){ Id = 3, Name= "Delicate Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Neutral" },
                    new CareItem(){ Id = 4, Name= "Aniline Calf Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Neutral"},
                    new CareItem(){ Id = 5, Name= "Cream Naturale", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Neutral" },
                    new CareItem(){ Id = 6, Name= "Cream Naturale", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Burgandy" },
                    new CareItem(){ Id = 7, Name= "Cream Naturale", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Brown" },
                    new CareItem(){ Id = 9, Name= "Shoe Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Black" },
                    new CareItem(){ Id = 10, Name= "Cordovan Cream Renovator", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Black" },
                    new CareItem(){ Id = 11, Name= "Bees Aging Oil", CareCategory = CareCategory.Oil, CareBrand = mowbray },
                    new CareItem(){ Id = 12, Name= "Leather Balsam", CareCategory = CareCategory.Oil, CareBrand = renapur },
                    new CareItem(){ Id = 13, Name = "Leather Creaner", CareCategory = CareCategory.Cleaner, CareBrand= lexol },
                    new CareItem(){ Id = 14, Name = "Leather Conditioner", CareCategory = CareCategory.Oil, CareBrand= lexol },
                    new CareItem(){ Id = 15, Name = "Stain Remover", CareCategory = CareCategory.Cleaner,  CareBrand = mowbray },
                    new CareItem(){ Id = 16, Name = "Stain Creansing Water", CareCategory = CareCategory.Cleaner, CareBrand = mowbray },
                    new CareItem(){ Id = 17, Name = "Welt Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Black" },
                    new CareItem(){ Id = 18, Name = "Welt Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Brown" },
                    new CareItem(){ Id = 99, Name = "Extra", CareCategory = CareCategory.Extra, CareBrand = uw }
                };
                foreach (CareItem ci in careitems) context.CareItem.Add(ci);

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareItem ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareItem OFF");
            }

            // History
            if (!context.History.Any())
            {
                // CSVファイル名直接指定して読み込む
                var histories = CsvRead.ReadFile<History>("C:\\Users\\h_san\\source\\repos\\ShoeCareHistory\\ShoeCareHistory\\App_Data\\CSV\\History.csv");
                foreach (var h in histories) context.History.Add(h);

                //ShoeMaker smkr = null;

                //var histories = CsvRead.ReadFile("");
                //foreach (int i in histories.Keys)
                //{
                //    var data = histories[i];

                //    context.History.Add(new History()
                //    {
                //        Id = int.Parse(data[0]),
                //        CareDate = DateTime.Parse(data[4]),
                //        ShoeId = int.Parse(data[1]),
                //        CareItemId = int.Parse(data[5]),
                //        Detail = data[4]
                //    });
                //}

                // 変更をDBに反映
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ShoeMaker ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ShoeMaker OFF");
            }
            context.Database.CloseConnection();
        }
    }
}
