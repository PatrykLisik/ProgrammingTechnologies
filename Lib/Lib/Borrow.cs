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
        public Reader Who { set; get; }
        public BookDescription What { get; }
        public DateTime Date;


        public Borrow(Reader who, BookDescription what)
        {
            Who = who ?? throw new ArgumentNullException(nameof(who));
            What = what ?? throw new ArgumentNullException(nameof(what));
            Date = new DateTime();
            Date = DateTime.Today;
        }

    }
}
