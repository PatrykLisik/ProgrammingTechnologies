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
        //generating Random and mock object
        Random rng = new Random();
        String RandomString()
        {
            return Guid.NewGuid().ToString().Substring(0, 10);
        }
        Mock<Book> RandomBook()
        {
            return new Mock<Book>(RandomString(), RandomString());
        }
        Mock<Reader> RandomReader()
        {
            return new Mock<Reader>(RandomString(), RandomString(), rng.Next());
        }
        Mock<Borrow> RandomBorrow()
        {
           var MockBorrow = new Mock<Borrow>(RandomReader().Object, RandomBookDescription().Object);
           MockBorrow.Setup(borrow => borrow.ToString()).Returns("MOCK BORROW");
           return MockBorrow;
        }
        Mock<BookDescription> RandomBookDescription()
        {
            return new Mock<BookDescription>(RandomString(), RandomBook().Object);
        }
        DataContext PrepareDataContext(int size)
        {

            DataContext data = new DataContext();
            for (int i = 0; i < size; i++)
            {
                data.BookDescriptions.Add(RandomBookDescription().Object);
                data.Books.Add(RandomBook().Object);
                data.Borrows.Add(RandomBorrow().Object);
                data.Readers.Add(RandomReader().Object);
            }
            return data;
        }
        //actual tests
        [TestMethod()]
        public void FillTest()
        {
            const int DataSize = 3000;
            //Mock data filler
            var MockDataFiller = new Mock<IDataFiller>();
            MockDataFiller.Setup(foo => foo.FillAll()).Returns(PrepareDataContext(DataSize));

            DataRepository dataRepository = new DataRepository();

            //assume that setFiller works correctly
            dataRepository.SetFiller(MockDataFiller.Object); //set filler
            dataRepository.Fill(); // fill with objects 

            //test if Data has been filled
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);

            Assert.AreEqual(DataSize, dataContext.BookDescriptions.Count());
            Assert.AreEqual(DataSize, dataContext.Books.Count());
            Assert.AreEqual(DataSize, dataContext.Readers.Count());
            Assert.AreEqual(DataSize, dataContext.Borrows.Count());
        }

        [TestMethod()]
        public void SetFillerTest()
        {
            //Mock data filler
            var MockDataFiller = new Mock<IDataFiller>();
            DataRepository dataRepository = new DataRepository();

            //SetFiller
            dataRepository.SetFiller(MockDataFiller.Object);

            //Reflect filler
            var filler = typeof(DataRepository).GetField("Filler", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            IDataFiller dataCactualFiller = (IDataFiller)filler.GetValue(dataRepository);

            //check filler
            Assert.AreSame(dataCactualFiller, MockDataFiller.Object);
        }

        [TestMethod()]
        public void AddBookTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBook = RandomBook();
            dataRepository.AddBook(MockBook.Object);
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
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
            DataRepository dataRepository = new DataRepository();
            var MockBorrow = RandomBorrow();
            dataRepository.AddBorrow(MockBorrow.Object);
            Borrow borrow = dataRepository.GetBorrow(0);
            Assert.AreEqual(borrow, MockBorrow.Object);

            dataRepository.DeleteBorrow(0);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(0, dataContext.Borrows.Count());

            //Test object given by getAllBooks method
            Assert.AreEqual(0, dataRepository.GetAllBorrows().Count());

        }

        [TestMethod()]
        public void AddBookDescriptionTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBookDescription = RandomBookDescription();

            dataRepository.AddBookDescription(MockBookDescription.Object);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(1, dataContext.BookDescriptions.Count());

            //Test object given by getAllBooks method
            Assert.AreEqual(1, dataRepository.GetAllBookDescriptions().Count());
        }

        [TestMethod()]
        public void GetBookDescriptionTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBookDescription = RandomBookDescription();

            dataRepository.AddBookDescription(MockBookDescription.Object);

            BookDescription bookDescription = dataRepository.GetBookDescription(0);
            Assert.AreEqual(bookDescription, MockBookDescription.Object);
        }

        [TestMethod()]
        public void GetAllBookDescriptionsTest()
        {
            const int NUMBER_OF_BOOK_DESCRIPTION = 100;
            DataRepository dataRepository = new DataRepository();
            var ExpectedBookDescriptionlist = new List<BookDescription>();

            for (int i = 0; i < NUMBER_OF_BOOK_DESCRIPTION; i++)
            {
                var MockBookDescription = RandomBookDescription();

                dataRepository.AddBookDescription(MockBookDescription.Object);
                ExpectedBookDescriptionlist.Add(MockBookDescription.Object);
            }

            Assert.IsTrue(ExpectedBookDescriptionlist.SequenceEqual(dataRepository.GetAllBookDescriptions()));

        }

        [TestMethod()]
        public void UpdateBookDescriptionTest()
        {
            //preperation is the same as in addBook
            DataRepository dataRepository = new DataRepository();
            var MockBookDescription = RandomBookDescription();
            dataRepository.AddBookDescription(MockBookDescription.Object);
            BookDescription bookkDescription = dataRepository.GetBookDescription(0);
            Assert.AreEqual(bookkDescription, MockBookDescription.Object);

            //test if book can be changed
            var MockBookDescription2 = RandomBookDescription();
            dataRepository.UpdateBookDescription(0, MockBookDescription2.Object);

            Assert.AreEqual(MockBookDescription2.Object, dataRepository.GetBookDescription(0));

        }

        [TestMethod()]
        public void DeleteBookDescriptionTest()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBookDescription = RandomBookDescription();
            dataRepository.AddBookDescription(MockBookDescription.Object);
            BookDescription bookDescription = dataRepository.GetBookDescription(0);
            Assert.AreEqual(bookDescription, MockBookDescription.Object);

            dataRepository.DeleteBookDescription(0);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(0, dataContext.Books.Count());

            //Test object given by getAllBooks method
            Assert.AreEqual(0, dataRepository.GetAllBookDescriptions().Count());

        }

        [TestMethod()]
        public void AddBookNumberTest()
        {
            var Book1 = RandomBookDescription();
            int Number1 = rng.Next();
            var Book2 = RandomBookDescription();
            int Number2 = rng.Next();
            DataRepository dataRepository = new DataRepository();

            dataRepository.AddBookNumber(Book1.Object, Number1);
            dataRepository.AddBookNumber(Book2.Object, Number2);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);

            Assert.AreEqual(2, dataContext.NumberOfBooks.Count());
            Assert.IsTrue(dataContext.NumberOfBooks.ContainsKey(Book1.Object));
            Assert.IsTrue(dataContext.NumberOfBooks.ContainsKey(Book2.Object));
            Assert.IsTrue(dataContext.NumberOfBooks.ContainsValue(Number1));
            Assert.IsTrue(dataContext.NumberOfBooks.ContainsValue(Number2));


        }

        [TestMethod()]
        public void ChangeBookNumberTest()
        {
            var Book1 = RandomBookDescription();
            int Old = rng.Next()%1000000;
            int Change = rng.Next()%10000;
            DataRepository dataRepository = new DataRepository();

            //assume add is working
            dataRepository.AddBookNumber(Book1.Object, Old);


            dataRepository.ChangeBookNumber(Book1.Object, Change);


            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);
            Assert.AreEqual(Old + Change, dataContext.NumberOfBooks[Book1.Object]);
        }

        [TestMethod()]
        public void GetBookNumberTest()
        {
            var Book1 = RandomBookDescription();
            int Old = rng.Next();
            DataRepository dataRepository = new DataRepository();
            //assume add is working
            dataRepository.AddBookNumber(Book1.Object, Old);

            //Test reflected object
            var data = typeof(DataRepository).GetField("Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DataContext dataContext = (DataContext)data.GetValue(dataRepository);


            Assert.AreEqual(Old, dataContext.NumberOfBooks[Book1.Object]);

           
        }

        [TestMethod()]
        public void GetAllNumberOfBooksTest()
        {
            const int NUMBER_OF_BOOK_NUMBERS = 1000;
            DataRepository dataRepository = new DataRepository();
            Dictionary<BookDescription, int> Expected = new Dictionary<BookDescription, int>();

            for(int i = 0; i < NUMBER_OF_BOOK_NUMBERS; i++)
            {
                var MockBookDescripion = RandomBookDescription();
                int Number = rng.Next();
                dataRepository.AddBookNumber(MockBookDescripion.Object, Number);
                Expected.Add(MockBookDescripion.Object, Number);
            }

            Assert.AreSame(dataRepository.GetAllNumberOfBooks().Keys.ToString(),Expected.Keys.ToString());
            Assert.AreSame(dataRepository.GetAllNumberOfBooks().Values.ToString(),Expected.Values.ToString());
            Assert.AreSame(Expected.ToString(), dataRepository.GetAllNumberOfBooks().ToString());
        }

        [TestMethod]
        public void BorrowConsoleNotificationAdd()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBorrow = RandomBorrow();
            String expectedOut = "Change type: Add\r\nItems added: \r\nMOCK BORROW\r\n"; ;
            using (var consoleLogger = new ConsoleMiddleman())
            {
                dataRepository.AddBorrow(MockBorrow.Object);
                Assert.IsFalse(String.IsNullOrEmpty(consoleLogger.GetOuput()));
                Assert.IsTrue(String.Equals(expectedOut, consoleLogger.GetOuput()));

            }
            Console.Write(expectedOut);
        }

        [TestMethod]
        public void BorrowConsoleNotificationDelete()
        {
            DataRepository dataRepository = new DataRepository();
            var MockBorrow = RandomBorrow();
            String expectedOut = "Change type: Remove\r\nItems removed: \r\nMOCK BORROW\r\n";
            dataRepository.AddBorrow(MockBorrow.Object);

            using (var consoleLogger = new ConsoleMiddleman())
            {
                dataRepository.DeleteBorrow(0);
                Assert.IsFalse(String.IsNullOrEmpty(consoleLogger.GetOuput()));
                Assert.IsTrue(String.Equals(expectedOut, consoleLogger.GetOuput()));

            }
            Console.Write(expectedOut);
        }

    }
}
