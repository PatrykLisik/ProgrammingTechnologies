using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //opis stanu 
    [Serializable]
    public class BookDescription
    {
        public string Type { get; }
        public Book book { get; }

        public BookDescription(string Type, Book book)
        {
            this.Type = Type ?? throw new ArgumentNullException(nameof(Type));
            this.book = book ?? throw new ArgumentNullException(nameof(book));
        }

        public override string ToString()
        {
            return String.Format("BookDescription: {0} of type {1}",book,Type);
        }
    }
}
