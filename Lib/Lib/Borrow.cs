using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //zadrzenie 
    public class Borrow
    {
        Reader Who;
        BookDescription What;
        DateTime Date;


        public Borrow(Reader who, BookDescription what)
        {
            Who = who ?? throw new ArgumentNullException(nameof(who));
            What = what ?? throw new ArgumentNullException(nameof(what));
            Date = new DateTime();
            Date = DateTime.Today;
        }

    }
}
