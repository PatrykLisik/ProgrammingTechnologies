using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //zdarzenie 
    public class Borrow
    {
        public Reader Who { get; }
        public BookDescription What { get; }
        public DateTime Date { get; }


        public Borrow(Reader who, BookDescription what)
        {
            Who = who ?? throw new ArgumentNullException(nameof(who));
            What = what ?? throw new ArgumentNullException(nameof(what));
            Date = new DateTime();
            Date = DateTime.Today;
        }

        public override string ToString()
        {
            return String.Format("Borrow of: {0} by {1} on {2}",What,Who,Date);
        }
    }
}
