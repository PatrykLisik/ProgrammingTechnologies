using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //wykaz 
    [Serializable]
    public class Reader:IComparable<Reader>
    {
       public string Name { get;  }
       public string Surname { get;  }
       public int Age { get; }


        public Reader(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        //Bad Readers delete and get all not passing
        //Possible reason: AreEqual is realying on those methods 
        /*
        public static bool operator ==(Reader lhs, Reader rhs)
        {
            return lhs.Name == rhs.Name && lhs.Surname == rhs.Surname;
        }
        public static bool operator !=(Reader lhs, Reader rhs)
        {
            return lhs.Name != rhs.Name || lhs.Surname != rhs.Surname;
        }

        public override bool Equals(object obj)
        {
            var reader = obj as Reader;
            return reader != null &&
                   Name == reader.Name &&
                   Surname == reader.Surname &&
                   Age == reader.Age;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        */
        public override string ToString()
        {
            return String.Format("Reader: {0} {1}", Name, Surname);
        }

        public int CompareTo(Reader other)
        {
            return Convert.ToInt32(other.Name == Name && other.Surname == Surname);
        }
    }
}
