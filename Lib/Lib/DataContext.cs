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
        public List<Borrow> Borrows { get; set; }
        public List<BookDescription> BookDescriptions { get; set; }
        public List<Reader> Readers { get; set; }

        public DataContext()
        {
            Books = new List<Book>();
            Borrows = new List<Borrow> ();
            BookDescriptions = new List<BookDescription>();
            Readers = new List<Reader>();
        }
    }
}
