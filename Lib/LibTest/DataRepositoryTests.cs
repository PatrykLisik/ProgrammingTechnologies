using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Lib.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        [TestMethod()]
        public void FillTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void SetFillerTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBook = new Mock<Book>("aaa", "bbb");
            dataRepository.AddBook(MockBook.Object);
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext) data.GetValue(dataRepository);
            Assert.AreEqual(1, dataContext.Books.Count());

        }

        [TestMethod()]
        public void GetBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBook = new Mock<Book>("aaa", "bbb");

            dataRepository.AddBook(MockBook.Object);

            Book book = dataRepository.GetBook(0);     
            Assert.AreEqual(book, MockBook.Object);
        }

        [TestMethod()]
        public void GetAllBooksTest()
        {
            const int NUMBER_OF_BOOK = 100;
            DataRepository dataRepository = new DataRepository();
            var ExpectedBooklist = new List<Book>();

            for (int i = 0; i < NUMBER_OF_BOOK; i++)
            {
                String randomString1 = Guid.NewGuid().ToString().Substring(0, 10);
                String randomString2 = Guid.NewGuid().ToString().Substring(0, 10);

                var MockBook = new Mock<Book>(randomString1, randomString2);

                dataRepository.AddBook(MockBook.Object);
                ExpectedBooklist.Add(MockBook.Object);
            }

            Assert.IsTrue(ExpectedBooklist.SequenceEqual(dataRepository.GetAllBooks()));
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            //preperation is the same as in addBook
            DataRepository dataRepository = new DataRepository();
            var MockBook = new Mock<Book>("First", "Book");
            dataRepository.AddBook(MockBook.Object);
            Book book = dataRepository.GetBook(0);
            Assert.AreEqual(book, MockBook.Object);

            //test if book can be changed
            var MockBook2 = new Mock<Book>("Diffrent", "Book");
            dataRepository.UpdateBook(0, MockBook2.Object);

            Assert.AreEqual(MockBook2.Object, dataRepository.GetBook(0));


        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBook = new Mock<Book>("First", "Book");
            dataRepository.AddBook(MockBook.Object);
            Book book = dataRepository.GetBook(0);
            Assert.AreEqual(book, MockBook.Object);

            dataRepository.DeleteBook(0);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(0, dataContext.Books.Count());

            //Test object given by getAllBooks method
            Assert.AreEqual(0, dataRepository.GetAllBooks().Count());

        }

        [TestMethod()]
        public void AddReaderTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockReader = new Mock<Reader>("aaa", "bbb",10);

            dataRepository.AddReader(MockReader.Object);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(1, dataContext.Readers.Count());

            //Test object given by getAllBooks method
            Assert.AreEqual(1, dataRepository.GetAllReaders().Count());
        }

        [TestMethod()]
        public void GetReaderTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockReader = new Mock<Reader>("aaa", "bbb", 10);

            dataRepository.AddReader(MockReader.Object);

            Reader book = dataRepository.GetReader(0);
            Assert.AreEqual(book, MockReader.Object);
        }

        [TestMethod()]
        public void GetAllReadersTest()
        {
            const int NUMBER_OF_READERS = 100;
            DataRepository dataRepository = new DataRepository();
            var ExpectedReaderlist = new List<Reader>();

            for (int i = 0; i < NUMBER_OF_READERS; i++)
            {
                String randomString1 = Guid.NewGuid().ToString().Substring(0, 10);
                String randomString2 = Guid.NewGuid().ToString().Substring(0, 10);

                var MockReader = new Mock<Reader>(randomString1, randomString2,i);

                dataRepository.AddReader(MockReader.Object);
                ExpectedReaderlist.Add(MockReader.Object);
            }

            Assert.IsTrue(ExpectedReaderlist.SequenceEqual(dataRepository.GetAllReaders()));
        }

        [TestMethod()]
        public void UpdateReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddBorrowTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetBorrowTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllBorrowsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateBorrowTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteBorrowTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddBookDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetBookDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllBookDescriptionsTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateBookDescriptionTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteBookDescriptionTest()
        {
            throw new NotImplementedException();
        }
    }
}
