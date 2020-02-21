using Hashcode2020OnlineRound.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hashcode2020OnlineRound.Logic
{
    public class Logic
    {
        public static List<OutputLibrary> SolutionV1(LibrariesForSignup data)
        {
            var deadline = data.Deadline;
            var outputs = new List<OutputLibrary>();

            for (int i = 0; i < data.Libraries.Count(); i++)
            {
                outputs.Add(new OutputLibrary
                {
                    ID = i,
                    Books = data.Libraries.ToList()[i].Books.Take(deadline).ToList(),
                    BooksCount = data.Libraries.ToList()[i].Books.Take(deadline).Count()
                });
            }

            return outputs;
        }

        public static void SolutionV2(LibrariesForSignup data)
        {
            var deadline = data.Deadline;
            var signUpedLibraries = new List<Library>();
            Library signUpedLibrary = null;
            var totalScore = 0;
            foreach (var library in data.Libraries)
            {
                foreach (var signUpedLibrary1 in signUpedLibraries)
                {

                }
                if (signUpedLibrary != null)
                {
                    var scanAbleBookCount = library.SignupTime / signUpedLibrary.ScanLimit;

                    var score = signUpedLibrary.Books.Where(b => b.ID <= scanAbleBookCount).Sum(b => b.Score);
                }
                totalScore += totalScore;

                signUpedLibraries.Add(library);
                //signUpedLibrary = library;
                deadline -= library.SignupTime;

            }
        }

        public static List<OutputLibrary> SolutionV3(LibrariesForSignup data)
        {
            var deadline = data.Deadline;
            var outputs = new List<OutputLibrary>();

            for (int i = 0; i < data.Libraries.Count(); i++)
            {
                deadline -= data.Libraries.ToList()[i].SignupTime;
                var take = deadline * data.Libraries.ToList()[i].ScanLimit;

                if (data.Libraries.ToList()[i].Books.Take(take).Any())
                {
                    outputs.Add(new OutputLibrary
                    {
                        ID = i,
                        Books = data.Libraries.ToList()[i].Books.Take(take).ToList(),
                        BooksCount = data.Libraries.ToList()[i].Books.Take(take).Count()
                    });
                }
            }

            return outputs;
        }

        public static List<OutputLibrary> SolutionV4(LibrariesForSignup data)
        {
            var libraries = new Dictionary<int, Library>();

            for (int i = 0; i < data.Libraries.Count(); i++)
            {
                libraries.Add(i, data.Libraries.ToList()[i]);
            }

            var deadline = data.Deadline;
            var outputs = new List<OutputLibrary>();

            libraries = libraries.OrderByDescending(l => l.Value.Books.Sum(b => b.Score)).ToDictionary(k => k.Key, v => v.Value);

            foreach (var library in libraries)
            {
                deadline -= library.Value.SignupTime;
                var take = deadline * library.Value.ScanLimit;

                if (library.Value.Books.Take(take).Any())
                {
                    outputs.Add(new OutputLibrary
                    {
                        ID = library.Key,
                        Books = library.Value.Books.OrderByDescending(b => b.Score).Take(take).ToList(),
                        BooksCount = library.Value.Books.Take(take).Count()
                    });
                }
            }

            return outputs;
        }

        public static List<OutputLibrary> SolutionV5(LibrariesForSignup data)
        {
            var otxodBooks = new List<int>();
            var libraries = new Dictionary<int, Library>();

            for (int i = 0; i < data.Libraries.Count(); i++)
            {
                libraries.Add(i, data.Libraries.ToList()[i]);
            }

            var deadline = data.Deadline;
            var outputs = new List<OutputLibrary>();

            libraries = libraries.OrderByDescending(l => l.Value.Books.Sum(b => b.Score)).ToDictionary(k => k.Key, v => v.Value);
            //libraries = libraries.OrderByDescending(l => l.Value.SignupTime).ToDictionary(k => k.Key, v => v.Value);

            foreach (var library in libraries)
            {
                deadline -= library.Value.SignupTime;
                var take = deadline * library.Value.ScanLimit;
                if (library.Value.Books.Where(b => !otxodBooks.Any(o => o == b.ID)).Take(take).Any())
                {
                    outputs.Add(new OutputLibrary
                    {
                        ID = library.Key,
                        Books = library.Value.Books.Where(b => !otxodBooks.Any(o => o == b.ID)).OrderByDescending(b => b.Score).Take(take).ToList(),
                        BooksCount = library.Value.Books.Take(take).Count()
                    });
                    otxodBooks.AddRange(library.Value.Books.OrderByDescending(b => b.Score).Take(take).Select(b => b.ID));
                }
            }

            return outputs;
        }
    }
}
