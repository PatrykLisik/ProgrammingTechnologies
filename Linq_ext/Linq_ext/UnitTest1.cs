using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq_ext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    namespace Ext_meth
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void Even()
            {
                List<int> numbers = Enumerable.Range(0, 20).ToList();
                List<int> even = numbers.Where(x => x % 2 == 0).ToList();
                foreach (int i in even)
                {
                    Console.WriteLine(i);
                    Assert.AreEqual(i%2, 0);
                }
            }

            [TestMethod]
            public void Order()
            {
                List<int> numbers = new List<int>{1, 2, 0};
                List<int> sorted = numbers.OrderBy(x => x.ToString()).ToList();
                for(int i=0; i<3; i++)
                {
                    Assert.AreEqual(i, sorted[i]);
                }
            }
        }
    }
}
