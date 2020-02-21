using System;
using System.Collections.Generic;
using System.Text;

namespace Hashcode2020OnlineRound.Entities
{
    public class OutputLibrary
    {
        public int ID { get; set; }
        public int BooksCount { get; set; }
        public List<Book> Books { get; set; }
    }
}
