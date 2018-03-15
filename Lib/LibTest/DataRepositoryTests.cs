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
            Assert.AreSame(book, MockBook.Object);
        }

        [TestMethod()]
        public void GetAllBooksTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateBookTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void AddReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetReaderTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void GetAllReadersTest()
        {
            throw new NotImplementedException();
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
