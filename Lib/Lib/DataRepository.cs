using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Lib
{
    public class DataRepository:IRepository
    {
        DataContext Data = new DataContext();
        IDataFiller Filler;

        public void Fill() { Data=Filler.FillAll(); }
        public void SetFiller(IDataFiller dataFiller) => Filler = dataFiller;

        //To do make it transaction 
        //Book aka Katalog
        public void AddBook(Book book) => Data.Books.Add(book);
        public Book GetBook(int id) { return Data.Books[id]; }
        public List<Book> GetAllBooks() { return Data.Books; }
        public void UpdateBook(int id, Book book) => Data.Books[id] = book;
        public void DeleteBook(int id) => Data.Books.Remove(GetBook(id));

        //Reader aka Wykaz
        public void AddReader(Reader reader) => Data.Readers.Add(reader);
        public Reader GetReader(int id) { return Data.Readers[id]; }
        public List<Reader> GetAllReaders() { return Data.Readers; }
        public void UpdateReader(int id, Reader reader) => Data.Readers[id] = reader;
        public void DeleteReader(int id) => Data.Readers.Remove(GetReader(id));

        //Borrow aka Zdarzenie
        public void AddBorrow(Borrow borrow) => Data.Borrows.Add(borrow);
        public Borrow GetBorrow(int id) { return Data.Borrows[id]; }
        public ObservableCollection<Borrow>  GetAllBorrows() { return Data.Borrows; }
        public void UpdateBorrow(int id, Borrow New) => Data.Borrows[id] = New;
        public void DeleteBorrow(int id) => Data.Borrows.Remove(GetBorrow(id));

        //BookDescription aka OpisStanu
        public void AddBookDescription(BookDescription bookDescriptions) => Data.BookDescriptions.Add(bookDescriptions);
        public BookDescription GetBookDescription(int id) { return Data.BookDescriptions[id]; }
        public List<BookDescription> GetAllBookDescriptions() { return Data.BookDescriptions; }
        public void UpdateBookDescription(int id, BookDescription bookDescription) => Data.BookDescriptions[id] = bookDescription;
        public void DeleteBookDescription(int id) => Data.BookDescriptions.Remove(GetBookDescription(id));

        //BookNumber 
        public void AddBookNumber(BookDescription book, int number)
        {
            Data.NumberOfBooks.Add(book, number);
        }

        public void ChangeBookNumber(BookDescription book, int number)
        {
            Data.NumberOfBooks[book] += number;
        }

        public int GetBookNumber(BookDescription book)
        {
            return Data.NumberOfBooks[book];
        }

        public Dictionary<BookDescription, int> GetAllNumberOfBooks()
        {
            //memberwiseClone not available
            return Data.NumberOfBooks; 
        }

        public void UpdateBookNumber( BookDescription book, int number)
        {
            Data.NumberOfBooks[book] = number; 
        }

        public void DeleteBookNumber(BookDescription book)
        {
            Data.NumberOfBooks.Remove(book);
        }
        
        //serializes data to 'fileName' file
        public void SaveData(String fileName)
        {
            using(var file = new System.IO.FileStream(fileName, System.IO.FileMode.Create))
            {
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(file, Data);

            }
        }

        //deserializes data from 'fileNmae'
        public void LoadData(String fileName)
        {
            using (var file = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                BinaryFormatter formater = new BinaryFormatter();
                Data = (DataContext)formater.Deserialize(file);
            }
        }

        public void SaveDataCustom(String fileName)
        {
            using (var file = new StreamWriter(fileName))
            {
                //save books
                file.WriteLine(Data.Books.Count);
                foreach (var book in Data.Books)
                {
                    file.WriteLine(book.Title);
                    file.WriteLine(book.Author);
                }

                //save readers
                file.WriteLine(Data.Readers.Count);
                foreach(var reader in Data.Readers)
                {
                    file.WriteLine(reader.Name);
                    file.WriteLine(reader.Surname);
                    file.WriteLine(reader.Age);
                }

                //save book descriptions
                file.WriteLine(Data.BookDescriptions.Count);
                foreach(var bookDesc in Data.BookDescriptions)
                {
                    file.WriteLine(bookDesc.Type);
                    file.WriteLine(Data.Books.IndexOf(bookDesc.book));
                }

                //save borrows
                file.WriteLine(Data.Borrows.Count);
                foreach (var borow in Data.Borrows)
                {
                    file.WriteLine(Data.Readers.IndexOf(borow.Who));
                    file.WriteLine(Data.BookDescriptions.IndexOf(borow.What));
                    file.WriteLine(borow.Date.Ticks);
                }

                //save number of books
                file.WriteLine(Data.NumberOfBooks.Count);
                foreach(var item in Data.NumberOfBooks)
                {
                    file.WriteLine(Data.BookDescriptions.IndexOf(item.Key));
                    file.WriteLine(item.Value);
                }
            }

        }

        public void LoadDataCustom(String fileName)
        {
            var newData = new DataContext();//get new data object

            using (var file = new StreamReader(fileName))
            {
                int count;

                //load books
                count = int.Parse(file.ReadLine());
                for(int i=0; i<count; i++)
                {
                    String title, author;
                    title = file.ReadLine();
                    author = file.ReadLine();

                    newData.Books.Add(new Book(title, author));
                }

                //load readers
                count = int.Parse(file.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    String name, surname;
                    int age;
                    name = file.ReadLine();
                    surname = file.ReadLine();
                    age = int.Parse(file.ReadLine());

                    newData.Readers.Add(new Reader(name, surname, age));
                }

                //load book description
                count = int.Parse(file.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    String type;
                    int bookId;
                    type = file.ReadLine();
                    bookId = int.Parse(file.ReadLine());

                    newData.BookDescriptions.Add(new BookDescription(type, newData.Books[bookId]));
                }

                //load borows
                count = int.Parse(file.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    int readerId, bookId;
                    Int64 timeTicks;
                    readerId = int.Parse(file.ReadLine());
                    bookId = int.Parse(file.ReadLine());
                    timeTicks = Int64.Parse(file.ReadLine());

                    newData.Borrows.Add(new Borrow(
                        newData.Readers[readerId], newData.BookDescriptions[bookId]));
                    newData.Borrows[i].ChangeDate(new DateTime(timeTicks));
                }

                //load number of books
                count = int.Parse(file.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    int bookId, val;
                    bookId = int.Parse(file.ReadLine());
                    val = int.Parse(file.ReadLine());

                    newData.NumberOfBooks.Add(newData.BookDescriptions[bookId], val);
                }
            }

            Data = newData;//save loaded data
        }

    }

}
