using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad3;


namespace Zad3
{
    class Program
    {
        static void Main(string[] args)
        {

            ADWDataContext dataContext = new ADWDataContext("localhost");
            var products = from product in dataContext.Products
                           where product.Name.Contains("Classic Vest")
                           select product;

            var ret= new List<Product>(products);
            foreach (var i in ret)
                Console.WriteLine(i.Name);
            Console.Read();
            return;
        }
    }
}
