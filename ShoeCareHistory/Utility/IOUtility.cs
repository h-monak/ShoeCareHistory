using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using ShoeCareHistory.Models;

namespace ShoeCareHistory.Utility
{
    public class IOUtility
    {
        public async Task OutputJsonAsync<T>(IEnumerable<T> type)
        {
            var fileName = Path.Combine("Data\\InOut", typeof(T).Name + ".json");
            var data = JsonConvert.SerializeObject(type, Formatting.Indented);

            using var writer = new StreamWriter(fileName, false, Encoding.UTF8);
            var task = writer.WriteLineAsync(data);
            await task;
        }

        public async Task<IEnumerable<T>> InputJsonAsync<T>(string fileName)
        {
            var data = "";

            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                data = await reader.ReadToEndAsync();
            }

            return (IEnumerable<T>)JsonConvert.DeserializeObject(data);
        }
    }
}
