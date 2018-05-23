using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3
{
    public static class ProductListExt
    {
        public static List<Product> NotCategorized(this List<Product> list)
        {
            return new List<Product>(list.Where(p => p.ProductSubcategoryID == null));
        }

        public static List<Product> GetPage(this List<Product> list, int itemsPerPage, int pageNumber)
        {
            return list.GetRange(pageNumber * itemsPerPage, itemsPerPage);
        }

        //toSting wolud be overwirtten by list method
        public static string ConvertToString(this List<Product> list)
        {
            var dataContext = Queries.DataContext;

            var results = from p in list
                          join pv in dataContext.ProductVendors on p.ProductID equals pv.ProductID
                          join v in dataContext.Vendors on pv.BusinessEntityID equals v.BusinessEntityID
                          select new { Prod = p, Vend = v }; // TUPLE EXIST

            string result = "";
            foreach (var pair in results)
            {
                result += pair.Prod.Name + "-" + pair.Vend.Name + "\n";
            }
            return result;
        }
    }
}

