using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ConstFiller : IDataFiller
    {
        Book book;
        Borrow borrow;
        Reader reader;
        BookDescription bookDescription;
        int amount;

        public ConstFiller(int amount)
        {
            this.amount = amount;
            book = new Book("Default Tilte", "Default Author");
            reader = new Reader("Default Name", "Default Surname", 42);
            bookDescription = new BookDescription("Default Type", book);
        }

        public ConstFiller(Book book, Borrow borrow, Reader reader, BookDescription bookDescription, int amount)
        {
            this.book = book ?? throw new ArgumentNullException(nameof(book));
            this.borrow = borrow ?? throw new ArgumentNullException(nameof(borrow));
            this.reader = reader ?? throw new ArgumentNullException(nameof(reader));
            this.bookDescription = bookDescription ?? throw new ArgumentNullException(nameof(bookDescription));
            this.amount = amount;
        }

        public DataContext FillAll()
        {
            DataContext dataContext = new DataContext();
            //No line length limit suggested, so I went wild 
            dataContext.Books = (Enumerable.Repeat(new Book(book.Title, book.Author), amount)).ToList();
            dataContext.Readers = (Enumerable.Repeat(new Reader(reader.Name, reader.Surname, reader.Age), amount)).ToList();
            dataContext.BookDescriptions = (Enumerable.Repeat(new BookDescription(bookDescription.Type, bookDescription.book), amount)).ToList();
            dataContext.Borrows = new System.Collections.ObjectModel.ObservableCollection<Borrow>((Enumerable.Repeat(new Borrow(reader, bookDescription), amount)).ToList());
            dataContext.NumberOfBooks = new Dictionary<BookDescription, int>() {{ bookDescription, amount }}; //only one bookDescription => only one key
            return dataContext;
        }
    }
}
