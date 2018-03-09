using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public abstract class DataFiller
    {
        public abstract void FillAll(DataContext context); 
    }
}
