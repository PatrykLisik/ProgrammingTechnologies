﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3
{
    public static class Queries
    {
        static ADWDataContext dataContext = new ADWDataContext("localhost");
        public static List<Product> GetProductsByName(string namePart)
        {
            var products = from product in dataContext.Products
                           where product.Name.Contains(namePart)
                           select product;

            return new List<Product>(products);
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            var products = from p in dataContext.Products
                           join pv in dataContext.ProductVendors on p.ProductID equals pv.ProductID
                           join v in dataContext.Vendors on pv.BusinessEntityID equals v.BusinessEntityID
                           where v.Name == vendorName
                           select p;

            return new List<Product>(products);
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            var names = from p in dataContext.Products
                        join pv in dataContext.ProductVendors on p.ProductID equals pv.ProductID
                        join v in dataContext.Vendors on pv.BusinessEntityID equals v.BusinessEntityID
                        where v.Name == vendorName
                        select p.Name;

            return new List<string>(names);
        }

        public static string GetProductVendorByProductName(string productName)
        {
            try
            {
                return (from p in dataContext.Products
                        from v in dataContext.ProductVendors
                        where p.ProductID == v.ProductID && p.Name == productName
                        select v.Vendor.Name).First();
            }
            catch
            {
                return "";
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            return (from r in dataContext.ProductReviews
                    orderby r.ModifiedDate
                    select r.Product).Distinct().Take(howManyReviews).ToList();
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            return (from r in dataContext.ProductReviews
                    orderby r.ModifiedDate
                    select r.Product).Distinct().Take(howManyProducts).ToList();
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            try
            {
                return (from p in dataContext.Products
                        where p.ProductSubcategory.ProductCategory.Name == categoryName
                        orderby p.Name
                        select p).Take(n).ToList();
            }
            catch
            {
                return new List<Product>();
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            return (int)(from p in dataContext.Products
                         where p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID
                         select p).Sum(o => o.StandardCost);
        }
    }
}
