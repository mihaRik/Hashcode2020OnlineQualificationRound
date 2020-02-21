using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Hashcode2020OnlineRound.Entities;

namespace Hashcode2020OnlineRound
{
    class FileWriter
    {
        public static async Task ProcessOrderOutputForExcelAsync(List<OutputLibrary> outputs, string inputType)
        {
            using (var writer = new StreamWriter(Path.Combine(@"C:\Users\User\Desktop\HashCode2020Online output", inputType)))
            {
                await writer.WriteLineAsync(outputs.Count.ToString());

                foreach (var library in outputs)
                {
                    await writer.WriteLineAsync($"{library.ID} {library.Books.Count}");
                    await writer.WriteLineAsync(string.Join(" ", library.Books.Select(b => b.ID)));
                }
            }
        }
    }
}