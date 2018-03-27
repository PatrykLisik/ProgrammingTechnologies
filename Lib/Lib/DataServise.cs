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
        public List<Borrow>  BorrowsBetweenDates(DateTime start, DateTime end) {
            List<Borrow> ans = new List<Borrow>();
            //the whole list travrsal is sufficent for small list
            //if this botleneck chnage boorows and dates to hash map
            foreach (Borrow b in Data.GetAllBorrows())
            {
                if (b.Date>start && b.Date<end)
                {
                    ans.Add(b);
                }
            }

            return ans;
        }
        public void AddBorow(BookDescription book, Reader reader) {
            Data.AddBorrow(new Borrow(reader,book));
        }
        public void ShowBooks() { }
        public void ShowBorrows() { }
        public void ShowReaders() { }


        //Dependancy injection
        public DataService(IRepository data)
        {
            Data = data;
        }
    }
}
