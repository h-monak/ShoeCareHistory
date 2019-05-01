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
            try
            {
                context.Database.OpenConnection();

                var redwing = new ShoeMaker()
                {
                    Name = "RedWing",
                    Country = "United States",
                    Established = 1905
                };
                var whites = new ShoeMaker()
                {
                    Name = "White's Boots",
                    Country = "United States",
                    Established = 1850
                };
                var trickers = new ShoeMaker()
                {
                    Name = "Tricker's",
                    Country = "United Kingdom",
                    Established = 1829
                };
                var wolverine = new ShoeMaker()
                {
                    Name = "Wolverine",
                    Country = "United States",
                    Established = 1883
                };
                var regal = new ShoeMaker
                {
                    Name = "Regal",
                    Country = "United States",
                    Established = 1880
                };
                var jalan = new ShoeMaker()
                {
                    Name = "Jalan Sriwijaya",
                    Country = "Indonesia",
                    Established = 1919
                };
                var danner = new ShoeMaker()
                {
                    Name = "Danner",
                    Country = "United States",
                    Established = 1900
                };
                var other = new ShoeMaker()
                {
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

                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ShoeMaker ON");
                    context.SaveChanges();
                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ShoeMaker OFF");
                }

                // Shoes
                if (!context.Shoe.Any())
                {
                    var shoes = new Shoe[]
                    {
                    //new Shoe(){Name = "877", Code ="877", ProductName = "CLASSIC-WORKS-MOC-TOE", Color = "ORO-REGACY", Leather = "COWHIDE", ProductionDate = DateTime.Parse("16-11-12"), PurchaseDate = DateTime.Parse("16-11-19"), BreakInDate = DateTime.Parse("18-02-24"), ShoeMaker = redwing }
                
                    new Shoe(){ ShoeMaker = redwing, Name = "8166", Code = "8166", ProductName = "CLASSIC WORKS ROUND TOE", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-12-01"), BreakInDate = DateTime.Parse("13-12-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "8165", Code = "8165", ProductName = "CLASSIC WORKS ROUND TOE", Leather = "", Color = "BLACK CHROME", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-01-01"), BreakInDate = DateTime.Parse("13-01-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "875", Code = "875", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO REGACY", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-02-01"), BreakInDate = DateTime.Parse("14-02-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "8112", Code = "8112", ProductName = "IRON RANGER", Leather = "", Color = "ORO IGINAL", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-11-01"), BreakInDate = DateTime.Parse("13-11-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "2907", Code = "2907", ProductName = "LIINEMAN", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-10-01"), BreakInDate = DateTime.Parse("14-10-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "8271", Code = "8271", ProductName = "ENGENEER", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-09-27"), BreakInDate = DateTime.Parse("15-09-27"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9011", Code = "9011", ProductName = "BECKMAN", Leather = "", Color = "BLACK CHERRY FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-08-01"), BreakInDate = DateTime.Parse("13-08-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9013", Code = "9013", ProductName = "BECKMAN", Leather = "", Color = "CHESTNUT FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-05-01"), BreakInDate = DateTime.Parse("14-05-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9024", Code = "9024", ProductName = "BECKMAN CHUKKA", Leather = "", Color = "BLACK FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-10-22"), BreakInDate = DateTime.Parse("15-10-22"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = wolverine, Name = "1000MILE", Code = "1000MILE", ProductName = "1000MILE", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("14-01-01"), BreakInDate = DateTime.Parse("14-01-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = wolverine, Name = "W05342", Code = "W05342", ProductName = "1000MILE ADDISON", Leather = "", Color = "BROWN CHROME EXCEL", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("13-10-01"), BreakInDate = DateTime.Parse("13-10-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = whites, Name = "BOUNTY HUNTER", Code = "BOUNTY HUNTER", ProductName = "BOUNTY HUNTER", Leather = "", Color = "RED DOG SMOOTH", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-01-14"), BreakInDate = DateTime.Parse("16-01-14"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = whites, Name = "SEMI DRESS", Code = "SEMI DRESS", ProductName = "SEMI DRESS", Leather = "", Color = "SIENNA WATER BUFFALO", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-04-20"), BreakInDate = DateTime.Parse("16-04-20"), IsSold = false, Material = "WATER BUFFALO"},
                    new Shoe(){ ShoeMaker = regal, Name = "PLANE TOE", Code = "", ProductName = "PLANE TOE", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("12-07-01"), BreakInDate = DateTime.Parse("12-07-01"), IsSold = false, Material = "ガラス"},
                    new Shoe(){ ShoeMaker = regal, Name = "STRAIGHT CHIP", Code = "", ProductName = "STRAIGHT CHIP", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-03-01"), BreakInDate = DateTime.Parse("15-03-01"), IsSold = false, Material = "合皮"},
                    new Shoe(){ ShoeMaker = regal, Name = "ローファー", Code = "", ProductName = "ローファー", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("03-03-01"), BreakInDate = DateTime.Parse("03-03-01"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = other, Name = "STRAIGHT CHIP", Code = "", ProductName = "STRAIGHT CHIP", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-02-01"), BreakInDate = DateTime.Parse("15-02-01"), IsSold = false, Material = "ステアハイド"},
                    new Shoe(){ ShoeMaker = jalan, Name = "BLOGUE", Code = "", ProductName = "BLOGUE", Leather = "", Color = "BROWN", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("15-06-01"), BreakInDate = DateTime.Parse("15-06-01"), IsSold = false, Material = "CURF"},
                    new Shoe(){ ShoeMaker = jalan, Name = "PLANE TOE", Code = "", ProductName = "PLANE TOE", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-01-22"), BreakInDate = DateTime.Parse("16-01-22"), IsSold = false, Material = "CURF"},
                    new Shoe(){ ShoeMaker = redwing, Name = "877", Code = "877", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO REGACY", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("16-11-12"), BreakInDate = DateTime.Parse("16-11-19"), IsSold = true, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9046", Code = "9046", ProductName = "BECKMAN OXFORD", Leather = "", Color = "TEAK FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-03-02"), BreakInDate = DateTime.Parse("17-04-03"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9087", Code = "9087", ProductName = "BLUCHER OXFORD", Leather = "", Color = "BLACK", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-04-25"), BreakInDate = DateTime.Parse("17-05-08"), IsSold = false, Material = "HEFAHIDE"},
                    new Shoe(){ ShoeMaker = whites, Name = "SEMI DRESS", Code = "SEMI DRESS", ProductName = "SEMI DRESS", Leather = "", Color = "BROWN DRESS" , ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-06-29"), BreakInDate = DateTime.Parse("17-07-01"), IsSold = false, Material = "SEMI DRESS"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9032", Code = "9032", ProductName = "BECKMAN CHUKKA", Leather = "", Color = "BLACK CHERRY FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-08-11"), BreakInDate = DateTime.Parse("17-08-11"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = trickers, Name = "M6087", Code = "M6087", ProductName = "ETHAN MONKEY BOOTS", Leather = "", Color = "ACORN ANTIQUE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-10-14"), BreakInDate = DateTime.Parse("17-10-27"), IsSold = false, Material = "CURF"},
                    new Shoe(){ ShoeMaker = whites, Name = "BOUNTY HUNTER", Code = "BOUNTY HUNTER", ProductName = "BOUNTY HUNTER", Leather = "", Color = "BROWN DRESS", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-10-29"), BreakInDate = DateTime.Parse("17-11-03"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "2966", Code = "2966", ProductName = "ENGENEER", Leather = "", Color = "BLACK CLONEDICE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-11-03"), BreakInDate = DateTime.Parse("17-11-04"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "9079", Code = "9079", ProductName = "CHELSEA BOOTS", Leather = "", Color = "BLACK FEATHER STONE", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("17-12-17"), BreakInDate = DateTime.Parse("17-12-17"), IsSold = false,  Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "877", Code = "877", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO IGINAL", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("18-02-17"), BreakInDate = DateTime.Parse("18-02-17"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = redwing, Name = "899", Code = "899", ProductName = "CLASSIC WORKS MOC TOE", Leather = "", Color = "ORO RUSSET", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("18-02-24"), BreakInDate = DateTime.Parse("18-02-24"), IsSold = false, Material = "COWHIDE"},
                    new Shoe(){ ShoeMaker = danner, Name = "Danner Light", Code = "30457", ProductName = "Danner Light", Leather = "", Color = "CEDAR BROWN", ProductionDate = DateTime.MinValue, PurchaseDate = DateTime.Parse("18-12-20"), BreakInDate = DateTime.Parse("18-12-20"), IsSold = false, Material = "COWHIDE"},
                    };
                    foreach (Shoe s in shoes) context.Shoe.Add(s);

                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Shoe ON");
                    context.SaveChanges();
                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Shoe OFF");
                }

                var redWing = new CareBrand() { Name = "RedWing" };
                var mowbray = new CareBrand() { Name = "M.Mowbray" };
                var hirano = new CareBrand() { Name = "Hirano" };
                var beckman = new CareBrand() { Name = "Beckman" };
                var renapur = new CareBrand() { Name = "Renapur" };
                var lexol = new CareBrand() { Name = "Lexol" };
                var uw = new CareBrand() { Name = "Union Works" };

                // CareBrand
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

                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareBrand ON");
                    context.SaveChanges();
                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareBrand OFF");
                }

                // CareItem
                if (!context.CareItem.Any())
                {
                    var careitems = new CareItem[]
                    {
                    new CareItem(){ Name= "Leather Conditioner", CareCategory = CareCategory.Oil, CareBrand = redWing },
                    new CareItem(){ Name = "Boot Cream",  CareCategory = CareCategory.Cream, CareBrand = redWing, Color = "Oro Russet" },
                    new CareItem(){ Name= "Delicate Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Neutral" },
                    new CareItem(){ Name= "Aniline Calf Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Neutral"},
                    new CareItem(){ Name= "Cream Naturale", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Neutral" },
                    new CareItem(){ Name= "Cream Naturale", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Burgandy" },
                    new CareItem(){ Name= "Cream Naturale", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Brown" },
                    new CareItem(){ Name= "Shoe Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Black" },
                    new CareItem(){ Name= "Cordovan Cream Renovator", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Black" },
                    new CareItem(){ Name= "Bees Aging Oil", CareCategory = CareCategory.Oil, CareBrand = mowbray },
                    new CareItem(){ Name= "Leather Balsam", CareCategory = CareCategory.Oil, CareBrand = renapur },
                    new CareItem(){ Name = "Leather Creaner", CareCategory = CareCategory.Cleaner, CareBrand= lexol },
                    new CareItem(){ Name = "Leather Conditioner", CareCategory = CareCategory.Oil, CareBrand= lexol },
                    new CareItem(){ Name = "Stain Remover", CareCategory = CareCategory.Cleaner,  CareBrand = mowbray },
                    new CareItem(){ Name = "Stain Creansing Water", CareCategory = CareCategory.Cleaner, CareBrand = mowbray },
                    new CareItem(){ Name = "Welt Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Black" },
                    new CareItem(){ Name = "Welt Cream", CareCategory = CareCategory.Cream, CareBrand = mowbray, Color = "Brown" },
                    new CareItem(){ Name = "Extra", CareCategory = CareCategory.Extra, CareBrand = uw }
                    };
                    foreach (CareItem ci in careitems) context.CareItem.Add(ci);

                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareItem ON");
                    context.SaveChanges();
                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CareItem OFF");
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
                    //        (data[0]),
                    //        CareDate = DateTime.Parse(data[4]),
                    //        Shoe(data[1]),
                    //        CareItem(data[5]),
                    //        Detail = data[4]
                    //    });
                    //}

                    // 変更をDBに反映
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.History ON");
                    context.SaveChanges();
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.History OFF");
                }
                context.Database.CloseConnection();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
