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
    public class ThreeRedundantMethodsTests
    {
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            var productNames = new List<string> { "Adjustable Race", "LL Crankarm" };

            bool isNotEmpty = QueriesTests.TestForExistance(productNames, ThreeRedundantMethods.GetProductsByName);
            Assert.IsTrue(isNotEmpty);

            var notProductNames = new List<string> { "fFSFFxcc54515", "DFFFxxdADFfgg" };

            isNotEmpty = QueriesTests.TestForExistance(notProductNames, ThreeRedundantMethods.GetProductsByName);
            //double negation
            Assert.IsFalse(isNotEmpty);
        }

        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
            var vendorNames = new List<string> { "Trikes, Inc.", "Light Speed" };
            bool isNotEmpty = QueriesTests.TestForExistance(vendorNames, ThreeRedundantMethods.GetProductsByVendorName);
            Assert.IsTrue(isNotEmpty);

            var notVendorNames = new List<string> { "fFSFFxcc54515", "DFFFxxdADFfgg" };
            isNotEmpty = QueriesTests.TestForExistance(notVendorNames, ThreeRedundantMethods.GetProductsByVendorName);
            Assert.IsFalse(isNotEmpty);
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<int> revievNumber = new List<int> { 0, 1 };
            bool isNotEmpty = QueriesTests.TestForExistance(revievNumber, ThreeRedundantMethods.GetProductsWithNRecentReviews);
            Assert.IsTrue(isNotEmpty);
        }
    }
}