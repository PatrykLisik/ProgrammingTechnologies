using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Lib
{
    [Serializable]
    public class DataContext
    {
        public List<Book> Books { get; set; }
        public List<BookDescription> BookDescriptions { get; set; }
        public List<Reader> Readers { get; set; }
        public Dictionary<BookDescription,int> NumberOfBooks { get; set; }
        public ObservableCollection<Borrow> Borrows { get; set; }

        public DataContext()
        {
            Books = new List<Book>();
            Borrows = new ObservableCollection<Borrow>();
            Borrows.CollectionChanged += BorrowsChanged;
            BookDescriptions = new List<BookDescription>();
            Readers = new List<Reader>();
            NumberOfBooks = new Dictionary<BookDescription, int>();
        }

        private void BorrowsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Change type: " + e.Action);
            if (e.NewItems != null)
            {
                Console.WriteLine("Items added: ");
                foreach (var item in e.NewItems)
                {

                    Console.WriteLine(item);
                }
            }
            
            if (e.OldItems != null)
            {
                Console.WriteLine("Items removed: ");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
