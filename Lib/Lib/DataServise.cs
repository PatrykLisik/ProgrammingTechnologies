using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class DataService
    {
        IRepository Data;
        //Book aka Katalog
        public List<Book> GetAllBooks() { return Data.GetAllBooks(); }
        public List<Borrow> BorrowsOfReader(Reader reader) {
            List<Borrow> ans = new List<Borrow>();
            foreach (Borrow b in Data.GetAllBorrows() )
            {
                if (b.Who == reader)
                {
                    ans.Add(b);
                }
            }

            return ans;

        }
        //public List<Borrow>  BorrowsBetweenDates(DateTime start, DateTime end) { }
        //public void AddBorow(Book book, Reader reader) { }

        //Dependancy injection
        public DataService(IRepository data)
        {
            Data = data;
        }
    }
}
