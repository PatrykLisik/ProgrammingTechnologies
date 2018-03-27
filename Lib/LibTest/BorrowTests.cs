using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Tests
{
    [TestClass()]
    public class BorrowTests
    {
        [TestMethod()]
        public void BorrowConstructNotNull()
        {
            var ReaderMock = new Mock<Reader>("aaa","bbbb",10);
            var BookMock = new Mock<Book>("aaa", "bbbb");
            var BookDescriptionMock = new Mock<BookDescription>("aaa",BookMock.Object);
            try
            {
                var BorrowTestObj = new Borrow(ReaderMock.Object, BookDescriptionMock.Object);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void BorrowConstructNull()
        {
            BookDescription description = null;
            Reader reader = null;
            try
            {
                Borrow borrow = new Borrow(reader, description);
            }
            catch (ArgumentNullException) { }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}