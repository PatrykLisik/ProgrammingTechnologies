using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class RandomFiller:IDataFiller
    {
        Random rng = new Random();
        int amount;

        public RandomFiller(int amount)
        {
            this.amount = amount;
        }

        String RandomString()
        {
            return Guid.NewGuid().ToString().Substring(0, 10);
        }
        Book RandomBook()
        {
            return new Book(RandomString(), RandomString());
        }
        Reader RandomReader()
        {
            return new Reader(RandomString(), RandomString(), rng.Next());
        }
        Borrow RandomBorrow()
        {
            return new Borrow(RandomReader(), RandomBookDescription());
          
        }
        BookDescription RandomBookDescription()
        {
            return new BookDescription(RandomString(), RandomBook());
        }

        public DataContext FillAll()
        {
                DataContext dataContext = new DataContext();
                //No line length limit suggested, so I went wild 
                dataContext.Books = (Enumerable.Repeat(RandomBook(), amount)).ToList();
                dataContext.Readers = (Enumerable.Repeat(RandomReader(), amount)).ToList();
                dataContext.BookDescriptions = (Enumerable.Repeat(RandomBookDescription(), amount)).ToList();
                dataContext.Borrows = new System.Collections.ObjectModel.ObservableCollection<Borrow>((Enumerable.Repeat(RandomBorrow(), amount)).ToList());
                dataContext.NumberOfBooks = dataContext.BookDescriptions.Distinct().ToDictionary(x => x, x => rng.Next());
                return dataContext;
            }
        
    }
}
