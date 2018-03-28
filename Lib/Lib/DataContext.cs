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
            Debug.WriteLine("Change type: " + e.Action);
            if (e.NewItems != null)
            {
                Debug.WriteLine("Items added: ");
                foreach (var item in e.NewItems)
                {
                    Debug.WriteLine(item);
                }
            }

            if (e.OldItems != null)
            {
                Debug.WriteLine("Items removed: ");
                foreach (var item in e.OldItems)
                {
                    Debug.WriteLine(item);
                }
            }
        }
    }
}
