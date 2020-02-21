using System;
using System.Collections.Generic;
using System.Text;

namespace Hashcode2020OnlineRound.Entities
{
    public class Library
    {
        public IEnumerable<Book> Books { get; set; }
        public int SignupTime { get; set; }
        public int ScanLimit { get; set; }
    }
}
