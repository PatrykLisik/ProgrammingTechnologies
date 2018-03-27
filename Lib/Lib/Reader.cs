using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //wykaz 
    public class Reader
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        public static bool operator ==(Reader lhs, Reader rhs)
        {
            return lhs.Name == rhs.Name && lhs.Surname == rhs.Surname;
        }
        public static bool operator !=(Reader lhs, Reader rhs)
        {
            return lhs.Name != rhs.Name || lhs.Surname != rhs.Surname;
        }
        public Reader(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            var reader = obj as Reader;
            return reader != null &&
                   Name == reader.Name &&
                   Surname == reader.Surname &&
                   Age == reader.Age;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
