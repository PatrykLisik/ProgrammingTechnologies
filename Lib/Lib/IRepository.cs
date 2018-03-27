using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public interface IRepository
    {
        //Force to have filler in some way
        void Fill();
        void SetFiller(IDataFiller dataFiller);

        //Book aka Katalog
        void AddBook(Book book);
        Book GetBook(int id);
        List<Book> GetAllBooks();
        void UpdateBook(int id, Book book);
        void DeleteBook(int id);

        //Reader aka Wykaz
        void AddReader(Reader reader);
        Reader GetReader(int id);
        List<Reader> GetAllReaders();
        void UpdateReader(int id, Reader reader);
        void DeleteReader(int id);

        //Borrow aka Zdarzenie
        void AddBorrow(Borrow borrow);
        Borrow GetBorrow(int id);
        List<Borrow> GetAllBorrows();
        void UpdateBorrow(int id, Borrow New);
        void DeleteBorrow(int id);

        //BookDescription aka OpisStanu
        void AddBookDescription(BookDescription bookDescriptions);
        BookDescription GetBookDescription(int id);
        List<BookDescription> GetAllBookDescriptions();
        void UpdateBookDescription(int id, BookDescription bookDescription);
        void DeleteBookDescription(int id);
    }
}
