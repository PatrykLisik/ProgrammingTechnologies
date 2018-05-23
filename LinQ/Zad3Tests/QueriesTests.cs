using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3.Tests
{
    [TestClass()]
    public class QueriesTests
    {
        private bool TestForExistance<FuncIn, FuncOut>(List<FuncIn> argsFroFunc, Func<FuncIn, List<FuncOut>> func)
        {

            bool ret = false;
            foreach (FuncIn arg in argsFroFunc)
            {
                List<FuncOut> funOut = func(arg);
                bool isEmpty = funOut.Capacity > 0;
                ret |= isEmpty;
            }

            return ret;
        }


        [TestMethod()]
        public void GetProductsByNameTest()
        {
            var productNames = new List<string> { "Adjustable Race", "LL Crankarm" };

            bool isNotEmpty = TestForExistance(productNames, Queries.GetProductsByName);
            Assert.IsTrue(isNotEmpty);

            var notProductNames = new List<string> { "fFSFFxcc54515", "DFFFxxdADFfgg" };

            isNotEmpty = TestForExistance(notProductNames, Queries.GetProductsByName);
            //double negation
            Assert.IsFalse(isNotEmpty);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            var vendorNames = new List<string> { "Trikes, Inc.", "Light Speed" };
            bool isNotEmpty = TestForExistance(vendorNames, Queries.GetProductsByVendorName);
            Assert.IsTrue(isNotEmpty);

            var notVendorNames = new List<string> { "fFSFFxcc54515", "DFFFxxdADFfgg" };
            isNotEmpty = TestForExistance(notVendorNames, Queries.GetProductsByVendorName);
            Assert.IsFalse(isNotEmpty);
        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
            var vendorNames = new List<string> { "Trikes, Inc.", "Light Speed" };
            bool isNotEmpty = TestForExistance(vendorNames, Queries.GetProductNamesByVendorName);
            Assert.IsTrue(isNotEmpty);

            var notVendorNames = new List<string> { "fFSFFxcc54515", "DFFFxxdADFfgg" };
            isNotEmpty = TestForExistance(notVendorNames, Queries.GetProductNamesByVendorName);
            Assert.IsFalse(isNotEmpty);
        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
            const string VENDOR_NAME = "Trikes, Inc.";
            var result = Queries.GetProductNamesByVendorName(VENDOR_NAME);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Mountain Tire Tube", result[0]);
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {

            List<int> revievNumber = new List<int> { 0, 1 };
            bool isNotEmpty = TestForExistance(revievNumber, Queries.GetProductsWithNRecentReviews);
            Assert.IsTrue(isNotEmpty);
        }

        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<int> revievNumber = new List<int> { 0, 1 };
            bool isNotEmpty = TestForExistance(revievNumber, Queries.GetNRecentlyReviewedProducts);
            Assert.IsTrue(isNotEmpty);
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
            
            var args = new List<Tuple<string, int>>
              {
                  new Tuple<string, int>("Bikes", 10),
                  new Tuple<string, int>("Components", 5),
                  new Tuple<string, int>("Clothing", 5)           

              };
            bool isNotEmpty = TestForExistance(args, Queries.GetNProductsFromCategory);
            Assert.IsTrue(isNotEmpty);

            var badArgs = new List<Tuple<string, int>>
              {
                  new Tuple<string, int>("fasf", 10),
                  new Tuple<string, int>("adafd", 5),
                  new Tuple<string, int>("Clotdadafaf33hing", 5)

              };
            isNotEmpty = TestForExistance(badArgs, Queries.GetNProductsFromCategory);
            Assert.IsFalse(isNotEmpty);


        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
            //untestable in diffrent way
            var categories = new List<ProductCategory>(3);
            foreach(ProductCategory c in categories)
            {
                int TSC = Queries.GetTotalStandardCostByCategory(c);
                Assert.IsTrue(TSC == 0);
            }
            
        }
    }
}