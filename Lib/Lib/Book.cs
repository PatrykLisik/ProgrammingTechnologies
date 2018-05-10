using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //katalog
    [Serializable]
    public class Book
    {
       public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public override string ToString()
        {
           return String.Format("Book: {0} by {1}", Title, Author);
        }
    }
}
