using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public interface DataFiller
    {
        void FillAll(DataContext context); 
    }
}
