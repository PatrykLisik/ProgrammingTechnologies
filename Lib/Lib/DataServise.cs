using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class DataService
    {
        public IRepository Data { set; get; }
        //Book aka Katalog
        public List<Book> GetAllBooks() { return Data.GetAllBooks(); }
        public List<Borrow> BorrowsOfReader(Reader reader)
        {
            List<Borrow> ans = new List<Borrow>();
            foreach (Borrow b in Data.GetAllBorrows())
            {
                if (b.Who == reader)
                {
                    ans.Add(b);
                }
            }

            return ans;

        }
        public List<Borrow> BorrowsBetweenDates(DateTime start, DateTime end)
        {
            List<Borrow> ans = new List<Borrow>();
            //the whole list travrsal is sufficent for small list
            //if this botleneck chnage boorows and dates to hash map
            foreach (Borrow b in Data.GetAllBorrows())
            {
                if (b.Date > start && b.Date < end)
                {
                    ans.Add(b);
                }
            }

            return ans;
        }
        public void AddBorow(BookDescription book, Reader reader)
        {
            Data.AddBorrow(new Borrow(reader, book));
        }
        public void ShowBooks()
        {
            Console.WriteLine("Books:\n");
            foreach (Book b in Data.GetAllBooks())
            {
                Console.WriteLine(b + "\n");
            }
            Console.WriteLine("\n\n");
        }
        public void ShowBorrows()
        {
            Console.WriteLine("Borrows:\n");
            foreach (Borrow b in Data.GetAllBorrows())
            {
                Console.WriteLine(b + "\n");
            }
            Console.WriteLine("\n\n");
        }
        public void ShowBorrowsOfEveryReaders()
        {
            Console.WriteLine("Borrow of every reader:\n");
            foreach (Reader r in Data.GetAllReaders())
            {
                Console.WriteLine(r);
                foreach (Borrow br in BorrowsOfReader(r))
                {
                    Console.WriteLine("\t->" + br);
                }
            }
            Console.WriteLine("\n\n");
        }
        public void ShowReaders()
        {
            Console.WriteLine("Readers:\n");
            foreach (Reader b in Data.GetAllReaders())
            {
                Console.WriteLine(b + "\n");
            }
            Console.WriteLine("\n\n");
        }
        public void ShowAll()
        {
            ShowBooks();
            ShowBorrowsOfEveryReaders();
        }


        //Dependancy injection
        public DataService(IRepository data)
        {
            Data = data;
        }
    }
}
