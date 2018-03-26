using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public interface IDataFiller
    {
        void FillAll(DataContext context); 
    }
}
