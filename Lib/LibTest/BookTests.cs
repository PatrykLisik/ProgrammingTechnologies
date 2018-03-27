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
            try
            {
                var BookTestObj = new Book("aaa", "bbb");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}