using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class StaticDataFiller: DataFiller
    {
        public void FillAll(DataContext context)
        {
            context = new DataContext();

            //add readers
            context.Readers.add(Reader("name1", "surname1", 20));

            //insert some books description
            context.BookDescriptions.add(Bookdescription("title1", "author1"));
            
            //add borrow
            context.Borrows.add(Borrow(context.Readers[0], context.BookDescriptions[0]));

            //don't know what's the deal with books and books description ?
        } 

    }
}
