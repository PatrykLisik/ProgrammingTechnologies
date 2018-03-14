using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class DataContext
    {
        public List<Book> Books { get; set; }
        public Dictionary<Borrow, DateTime> Borrows { get; set; }
        public List<BookDescription> BookDescriptions { get; set; }
        public List<Reader> Readers { get; set; }

    }
}
