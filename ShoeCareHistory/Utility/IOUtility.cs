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
        private readonly string tempDir = "Data\\InOut";

        public async Task OutputJsonAsync<T>(IEnumerable<T> data)
        {
            var fileName = Path.Combine(tempDir, typeof(T).Name + ".json");
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

            using var writer = new StreamWriter(fileName, false, Encoding.UTF8);
            var task = writer.WriteLineAsync(jsonData);
            await task;
        }

        public async Task<IEnumerable<T>> InputJsonAsync<T>()
        {
            var data = "";
            var fileName = Path.Combine(tempDir, typeof(T).Name + ".json");

            using (var reader = new StreamReader(fileName, Encoding.UTF8))
            {
                data = await reader.ReadToEndAsync();
            }

            return (IEnumerable<T>)JsonConvert.DeserializeObject(data);
        }
    }
}
