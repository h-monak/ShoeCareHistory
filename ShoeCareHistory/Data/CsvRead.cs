using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeCareHistory.Data
{
    public static class CsvRead
    {
        /// <summary>
        /// CSVファイル読み込む
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>
        /// 
        /// 
        /// </returns>
        public static Dictionary<int, List<string>> ReadFile(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var line = "";
                var datacnt = 0;
                var data = new List<string>();
                var retdata = new Dictionary<int, List<string>>();

                while ((line = sr.ReadLine()) != null)
                {
                    data = line.Split(',').ToList();
                    retdata.Add(datacnt, data);
                    datacnt++;
                }

                return retdata;
            }
        }
    }

    public class ShoeList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string Leather { get; set; }
        public string Color { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime PurchaseDate { get; set; }

        public ShoeList(string[] data)
        {
            
            this.Id = int.Parse(data[0]);

        }
    }

}
