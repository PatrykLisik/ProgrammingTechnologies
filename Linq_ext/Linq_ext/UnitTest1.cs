namespace Linq_ext
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Xml.Serialization;

    namespace Ext_meth
    {
        [TestClass]
        public class UnitTest1
        {

            [TestMethod]
            public void Order()
            {
                List<int> numbers = new List<int> { 1, 2, 0 };
                List<int> sorted = numbers.OrderBy(x => x.ToString()).ToList();
                for (int i = 0; i < 3; i++)
                {
                    Assert.AreEqual(i, sorted[i]);
                }
            }

            [TestMethod]
            public void Even()
            {
                //Test data
                List<int> numbers = Enumerable.Range(0, 20).ToList();
                Func<int,bool> foo = x => x % 2 == 0;
                Predicate<int> pred = x => x % 2 == 0;

                List<int> even1 = numbers.Where(x => x % 2 == 0).ToList();
                List<int> even2 = numbers.Where(foo).ToList();

                // bad cant compile
                //List<int> even2 = numbers.Where(pred).ToList();

                Assert.IsTrue(even1.All(even2.Contains));
                foreach (int i in even2)
                    Console.WriteLine(i);
            }
        }
    }
}
