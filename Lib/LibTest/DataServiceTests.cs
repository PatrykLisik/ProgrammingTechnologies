using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Collections.ObjectModel;

namespace Lib.Tests
{
    [TestClass()]
    public class DataServiceTests
    {
        Mock<IRepository> EmptyRepo()
        {
            var Ans = new Mock<IRepository>();
            Ans.Setup(foo => foo.GetAllBooks()).Returns(new List<Book>());
            // Ans.Setup(foo => foo.AddBorrow(Borrow b));
            Ans.Setup(foo => foo.GetAllBorrows()).Returns(new ObservableCollection<Borrow>());
            Ans.Setup(foo => foo.GetAllReaders()).Returns(new List<Reader>());
            Ans.Setup(foo => foo.GetAllBooks()).Returns(new List<Book>());

            return Ans;
        }

        //I know this should be in external file
        List<Book> BooksList()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("aaa", "bbb"));
            books.Add(new Book("ccc", "ddd"));
            books.Add(new Book("fff", "eee"));

            return books;
        }
        List<Reader> ReadersList()
        {
            List<Reader> readers = new List<Reader>();
            readers.Add(new Reader("FFFF", "GGGG", 21));
            readers.Add(new Reader("LLLL", "OOOO", 37));

            return readers;
        }
       List<BookDescription> BookDescriptionsList()
        {

            List<BookDescription> bookDescriptions = new List<BookDescription>();
            //All cases
            bookDescriptions.Add(new BookDescription("TTT", BooksList()[0]));
            bookDescriptions.Add(new BookDescription("DDD", BooksList()[1]));
            bookDescriptions.Add(new BookDescription("DDD", BooksList()[2]));
            bookDescriptions.Add(new BookDescription("WWW", BooksList()[0]));

            return bookDescriptions;
        }
        ObservableCollection<Borrow> BorrowsList()
        {
            ObservableCollection<Borrow> borrows = new ObservableCollection<Borrow>();
            borrows.Add(new Borrow(ReadersList()[0], BookDescriptionsList()[0]));
            borrows.Add(new Borrow(ReadersList()[0], BookDescriptionsList()[1]));
            borrows.Add(new Borrow(ReadersList()[0], BookDescriptionsList()[2]));
            borrows.Add(new Borrow(ReadersList()[1], BookDescriptionsList()[3]));

            return borrows;
        }
       Mock<IRepository> FilledRepo()
        {
            var Ans = new Mock<IRepository>();
            Ans.Setup(foo => foo.GetAllBooks()).Returns(BooksList());
            Ans.Setup(foo => foo.GetAllBorrows()).Returns(BorrowsList());
            Ans.Setup(foo => foo.GetAllReaders()).Returns(ReadersList());
            // Ans.Setup(foo => foo.AddBorrow(Borrow b));

            return Ans;
        }

      
        [TestMethod()]
        public void GetAllBooksTestEmptyRepo()
        {
            DataService EmptyDataService = new DataService(EmptyRepo().Object);

            List<Book> GivenBooklist = EmptyDataService.GetAllBooks();

            Assert.AreEqual(0, GivenBooklist.Count());

        }
        /*
        [TestMethod()]
        public void GetAllBooksTest()
        {
            throw new NotImplementedException();
        }
        */
        [TestMethod()]
        public void BorrowsOfReaderTestEmptyRepo()
        {
            DataService EmptyDataService = new DataService(EmptyRepo().Object);

            var BR = EmptyDataService.BorrowsOfReader(new Reader("as","aa",10));

            Assert.AreEqual(0, BR.Count());
        }
        //Not implenened tests commented into oblivion 
        /*
        [TestMethod()]
        public void BorrowsOfReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void BorrowsBetweenDatesTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddBorowTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ShowBorrowsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ShowBorrowsOfEveryReadersTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ShowReadersTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ShowAllTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DataServiceTest()
        {
            throw new NotImplementedException();
        }*/
    }
}