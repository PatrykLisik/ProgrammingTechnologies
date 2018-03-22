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
        Random rnd = new Random();
        String RandomString()
        {
           return  Guid.NewGuid().ToString().Substring(0, 10);
        }
        Mock<Book> RandomBook()
        {
            return new Mock<Book>(RandomString(), RandomString());
        }
        Mock<Reader> RandomReader()
        {
 
            return new Mock<Reader>(RandomString(), RandomString(), rnd.Next());
        }
        Mock<Borrow> RandomBorrow()
        {
            return new Mock<Borrow>(RandomReader().Object, RandomBookDescription().Object);
        }
        Mock<BookDescription> RandomBookDescription()
        {
            return new Mock<BookDescription>(RandomString(), RandomString());
        }
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
            var MockBook = RandomBook();
            dataRepository.AddBook(MockBook.Object);
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext) data.GetValue(dataRepository);
            Assert.AreEqual(1, dataContext.Books.Count());

        }

        [TestMethod()]
        public void GetBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBook = RandomBook();

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
                var MockBook = RandomBook();

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
            var MockBook = RandomBook();
            dataRepository.AddBook(MockBook.Object);
            Book book = dataRepository.GetBook(0);
            Assert.AreEqual(book, MockBook.Object);

            //test if book can be changed
            var MockBook2 = RandomBook();
            dataRepository.UpdateBook(0, MockBook2.Object);

            Assert.AreEqual(MockBook2.Object, dataRepository.GetBook(0));


        }

        [TestMethod()]
        public void DeleteBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBook = RandomBook();
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
            var MockReader = RandomReader();

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
            var MockReader = RandomReader();

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
                var MockReader = RandomReader();

                dataRepository.AddReader(MockReader.Object);
                ExpectedReaderlist.Add(MockReader.Object);
            }

            Assert.IsTrue(ExpectedReaderlist.SequenceEqual(dataRepository.GetAllReaders()));
        }

        [TestMethod()]
        public void UpdateReaderTest()
        {
            //preperation is the same as in addBook
            DataRepository dataRepository = new DataRepository();
            var MockReader = RandomReader();
            dataRepository.AddReader(MockReader.Object);
            Reader reader = dataRepository.GetReader(0);
            Assert.AreEqual(reader, MockReader.Object);

            //test if book can be changed
            var MockReader2 = RandomReader();
            dataRepository.UpdateReader(0, MockReader2.Object);

            Assert.AreEqual(MockReader2.Object, dataRepository.GetReader(0));

        }

        [TestMethod()]
        public void DeleteReaderTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockReader = RandomReader();
            dataRepository.AddReader(MockReader.Object);
            Reader reader = dataRepository.GetReader(0);
            Assert.AreEqual(reader, MockReader.Object);

            dataRepository.DeleteReader(0);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(0, dataContext.Readers.Count());

            //Test object given by getAllBooks method
            Assert.AreEqual(0, dataRepository.GetAllReaders().Count());
        }

        [TestMethod()]
        public void AddBorrowTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBorrow = RandomBorrow();
            dataRepository.AddBorrow(MockBorrow.Object);

            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(1, dataContext.Borrows.Count());
        }

        [TestMethod()]
        public void GetBorrowTest()
        {
            //Prepare 
            DataRepository dataRepository = new DataRepository();

            var MockBorrow = RandomBorrow();
            dataRepository.AddBorrow(MockBorrow.Object);

            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(1, dataContext.Borrows.Count());

            //Test 
            Borrow borrow = dataRepository.GetBorrow(0);
            Assert.AreEqual(borrow, MockBorrow.Object);


        }

        [TestMethod()]
        public void GetAllBorrowsTest()
        {
            const int NUMBER_OF_BORROWS = 500;
            DataRepository dataRepository = new DataRepository();
            var ExpectedBorowList = new List<Borrow>();
            for (int i = 0; i < NUMBER_OF_BORROWS; i++)
            {
                var MockBorrow = RandomBorrow();

                dataRepository.AddBorrow(MockBorrow.Object);
                ExpectedBorowList.Add(MockBorrow.Object);
            }

            Assert.IsTrue(ExpectedBorowList.SequenceEqual(dataRepository.GetAllBorrows()));

        }

        [TestMethod()]
        public void UpdateBorrowTest()
        {
            //preperation is the same as in addBorrow
            DataRepository dataRepository = new DataRepository();
            var MockBorrow1 = RandomBorrow();
            var MockBorrow2 = RandomBorrow();

            dataRepository.AddBorrow(MockBorrow1.Object);
            Borrow borrow = dataRepository.GetBorrow(0);
            Assert.AreEqual(borrow, MockBorrow1.Object);

            //test if book can be changed
       
            dataRepository.UpdateBorrow(0, MockBorrow2.Object);

            Assert.AreEqual(MockBorrow2.Object, dataRepository.GetBorrow(0));

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
