using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Warehouse
    {
        private Dictionary<Book, UInt32> NumberOfBook;
        public void AddBook(Book book, UInt32 number)
        {
            if (NumberOfBook.ContainsKey(book) == false)
            {
                NumberOfBook.Add(book, number);
                return;
            }
            NumberOfBook[book] += number;
        }
        public void RemoveBook(Book book) => RemoveBook(book, 1);

        public void RemoveBook(Book book, UInt32 number)
        {
            if(NumberOfBook.ContainsKey(book)==true && NumberOfBook[book]>number)
                NumberOfBook[book] -= number;
            else
                throw new ArgumentException(String.Format("{0} higher then current state", number));

        }


    }
}
