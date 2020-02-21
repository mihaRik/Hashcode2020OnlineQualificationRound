using Hashcode2020OnlineRound.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hashcode2020OnlineRound
{
    public class FileReader
    {
        public static async Task<LibrariesForSignup> GetLibrariesAsync(string inputTypes)
        {
            var fileLines = await File.ReadAllLinesAsync(Path.Combine(@"C:\Users\User\Desktop\HashCode2020Online", inputTypes));

            var firstLine = fileLines[0];
            var firsLineData = firstLine.Split(" ");
            var secondLine = fileLines[1];

            var scores = Array.ConvertAll<string, int>(secondLine.Split(" "), s => Convert.ToInt32(s));

            var libraries = new List<Library>();

            for (int i = 2; i < fileLines.Length; i = i + 2)
            {
                var line = fileLines[i];
                var lineData = line.Split(" ");
                var bookCount = Convert.ToInt32(lineData[0]);
                var signUpTime = Convert.ToInt32(lineData[1]);
                var scanLimit = Convert.ToInt32(lineData[2]);

                var booksLine = fileLines[i + 1];
                var books = booksLine.Split(" ");
                var booksList = new List<Book>();

                for (int j = 0; j < books.Length; j++)
                {
                    booksList.Add(new Book
                    {
                        ID = Convert.ToInt32(books[j]),
                        Score = scores[Convert.ToInt32(books[j])]
                    });
                }

                libraries.Add(new Library
                {
                    ScanLimit = scanLimit,
                    SignupTime = signUpTime,
                    Books = booksList
                });
            }

            return new LibrariesForSignup
            {
                BooksCount = Convert.ToInt32(firsLineData[0]),
                LibririesCount = Convert.ToInt32(firsLineData[1]),
                Deadline = Convert.ToInt32(firsLineData[2]),
                Libraries = libraries
            };
        }
    }
}
