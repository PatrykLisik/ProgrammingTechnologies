using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Reader
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }

        public Reader(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
