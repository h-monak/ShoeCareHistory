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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>newのパフォーマンスが悪い</remarks>
        /// <typeparam name="Type"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<Type> ReadFile<Type>(string filename)
         where Type : class, new()
        {
            var list = new List<Type>();
            var t = new Type();

            using (var sr = new StreamReader(filename))
            {
                var line = "";
                var rowcnt = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split(",");

                    try
                    {
                        if (rowcnt != 1)
                        {
                            if (t is Models.History)
                            {
                                var h = new Models.History();

                                h.Id = int.Parse(data[0]);
                                h.ShoeId = int.Parse(data[1]);
                                h.CareDate = DateTime.Parse(data[2]);
                                //h.SealDate = string.IsNullOrEmpty(data[3]) ? null : DateTime.Parse(data[3]);
                                h.Detail = data[4];
                                h.CareItemId = int.Parse(data[5]);

                                list.Add(h as Type);
                            }
                        }
                        rowcnt++;
                    }
                    catch (Exception ex)
                    { }
                }
            }

            return list;

        }
    }

    /// <summary>
    /// 
    /// </summary>
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
            this.Name = data[1];

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LogList
    {
        public int LogId { get; set; }
        public int ShoeId { get; set; }
        public string ShoeName { get; set; }
        public DateTime CareDate { get; set; }
        public string Detail { get; set; }

        public LogList() { }

        public LogList(string[] data)
        {
            this.LogId = int.Parse(data[0]);
            this.ShoeId = int.Parse(data[1]);
            this.ShoeName = data[2];
            this.CareDate = DateTime.Parse(data[4]);
            this.Detail = data[5];
        }
    }
}
