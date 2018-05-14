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
                    Console.WriteLine(i);
            }
        }
    }
}
