using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class DataContext
    {
        public List<Book> Books;
        public Dictionary<Borrow, DateTime> Borrows;
        public List<BookDescription> BookDescriptions;
        public List<Reader> Readers;

    }
}
