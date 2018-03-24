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
    public class BookTests
    {
        [TestMethod()]
        public void BookConstructorNoThorowTest()
        {

            var MockBookDescription = new Mock<BookDescription>("aaa", "bbb");
            try
            {
                var BookTestObj = new Book(MockBookDescription.Object);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void BookConstructorCorrectAssigment()
        {
            var MockBookDescription = new Mock<BookDescription>("aaa", "bbb");
            var BookTestObj = new Book(MockBookDescription.Object);

            //test with reflection 
            var PrivateBookDescription = typeof(Book).GetField("Description", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(BookTestObj);
            //Is this correct?
            //Assert.Equals(MockBookDescription.Object, PrivateBookDescription);
        }
    }
}