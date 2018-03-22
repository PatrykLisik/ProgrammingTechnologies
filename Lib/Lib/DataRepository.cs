using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class DataRepository:IRepository
    {
        DataContext Data = new DataContext();
        DataFiller Filler;

        public void Fill() { Filler.FillAll(Data); }
        public void SetFiller(DataFiller dataFiller) => Filler = dataFiller;

        //To do make it transaction 
        //Book aka Katalog
        public void AddBook(Book book) => Data.Books.Add(book);
        public Book GetBook(int id) { return Data.Books[id]; }
        public List<Book> GetAllBooks() { return Data.Books; }
        public void UpdateBook(int id, Book book) => Data.Books[id] = book;
        public void DeleteBook(int id) => Data.Books.Remove(GetBook(id));

        //Reader aka Wykaz
        public void AddReader(Reader reader) => Data.Readers.Add(reader);
        public Reader GetReader(int id) { return Data.Readers[id]; }
        public List<Reader> GetAllReaders() { return Data.Readers; }
        public void UpdateReader(int id, Reader reader) => Data.Readers[id] = reader;
        public void DeleteReader(int id) => Data.Readers.Remove(GetReader(id));

        //Borrow aka Zdarzenie
        public void AddBorrow(Borrow borrow) => Data.Borrows.Add(borrow);
        public Borrow GetBorrow(int id) { return Data.Borrows[id]; }
        public List<Borrow> GetAllBorrows() { return Data.Borrows; }
        public void UpdateBorrow(int id, Borrow New) => Data.Borrows[id] = New;
        public void DeleteBorrow(int id) => Data.Borrows.Remove(GetBorrow(id));

        //BookDescription aka OpisStanu
        public void AddBookDescription(BookDescription bookDescriptions) => Data.BookDescriptions.Add(bookDescriptions);
        public BookDescription GetBookDescription(int id) { return Data.BookDescriptions[id]; }
        public List<BookDescription> GetAllBookDescriptions() { return Data.BookDescriptions; }
        public void UpdateBookDescription(int id, BookDescription bookDescription) => Data.BookDescriptions[id] = bookDescription;
        public void DeleteBookDescription(int id) => Data.BookDescriptions.Remove(GetBookDescription(id));


    }

}
