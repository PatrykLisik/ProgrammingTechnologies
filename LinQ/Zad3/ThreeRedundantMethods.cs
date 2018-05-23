using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3
{
    public class ThreeRedundantMethods
    {
        public static List<MyProduct> GetProductsByName(string namePart)
        {
            return Queries.GetProductsByName(namePart).Select( p => new MyProduct(p)).ToList();
        }

        public static List<MyProduct> GetProductsByVendorName(string vendorName)
        {
            return Queries.GetProductsByVendorName(vendorName).Select(p => new MyProduct(p)).ToList();
        }

        public static List<MyProduct> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return Queries.GetProductsWithNRecentReviews(howManyReviews).Select(p => new MyProduct(p)).ToList();
        }
    }
}
