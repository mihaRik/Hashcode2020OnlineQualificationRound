using System;
using System.Collections.Generic;
using System.Text;

namespace Hashcode2020OnlineRound.Entities
{
    public class LibrariesForSignup
    {
        public int BooksCount { get; set; }
        public int LibririesCount { get; set; }
        public int Deadline { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
    }
}
