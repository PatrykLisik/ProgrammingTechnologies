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
            public void Even()
            {
                //Test data
                List<int> numbers = Enumerable.Range(0, 20).ToList();

                Func<int, bool> foo = x => x % 2 == 0;
                Predicate<int> pred = x => x % 2 == 0;

                List<int> even1 = numbers.Where(x => x % 2 == 0).ToList();
                List<int> even2 = numbers.Where(foo).ToList();

                //Bad compile error
                // List<int> even3 = numbers.Where(pred).ToList();

                //Assert that list are same elemnt-iwse
                Assert.IsTrue(even1.All(even2.Contains));

                Console.WriteLine("List:");
                foreach (int i in even2)
                    Console.WriteLine(i);


            }

            [TestMethod]
            public void XML()
            {
            }


        }
    }
}
