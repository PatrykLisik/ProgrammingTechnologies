using System;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Lib.Tests
{
    [TestClass]
    public class SerializeTest
    {
        //function for checking if two repositories contains same data
        //assuming preservation of indexes in lists
        bool CheckIfSame(DataRepository a, DataRepository b)
        {
            //check books
            var booksA = a.GetAllBooks();
            var booksB = b.GetAllBooks();

            if (booksA.Count != booksB.Count)
                return false;

            for (int i=0; i<booksA.Count; i++)
            {
                if (booksA[i].Title != booksB[i].Title || booksA[i].Author != booksB[i].Author)
                    return false;
            }


            //check readers
            var rdA = a.GetAllReaders();
            var rdB = b.GetAllReaders();

            if (rdA.Count != rdB.Count)
                return false;

            for (int i = 0; i < rdA.Count; i++)
            {
                if (rdA[i].Name != rdB[i].Name
                    || rdA[i].Surname != rdB[i].Surname
                    || rdA[i].Age != rdB[i].Age)
                    return false;
            }


            //check book descriptions
            var descA = a.GetAllBookDescriptions();
            var descB = b.GetAllBookDescriptions();

            if (descA.Count != descB.Count)
                return false;

            for (int i = 0; i < descA.Count; i++)
            {
                if (descA[i].Type != descB[i].Type
                    || a.GetAllBooks().IndexOf(descA[i].book) != b.GetAllBooks().IndexOf(descB[i].book))
                    return false;
            }


            //check borows
            var borA = a.GetAllBorrows();
            var borB = b.GetAllBorrows();


            if (borA.Count != borB.Count)
                return false;

            for(int i=0; i < borA.Count; i++)
            {
                if (a.GetAllReaders().IndexOf(borA[i].Who) != b.GetAllReaders().IndexOf(borB[i].Who)
                    || a.GetAllBookDescriptions().IndexOf(borA[i].What) != b.GetAllBookDescriptions().IndexOf(borB[i].What)
                    || borA[i].Date != borB[i].Date)
                    return false;
            }

            //check number of books
            //assuming that bookDesc in dictionary also exists in list of descrpitions
            //which should be the case
            
            var elemA = a.GetAllNumberOfBooks();
            var elemB = b.GetAllNumberOfBooks();

            if (elemA.Count != elemB.Count)
                return false;

            for (int i = 0; i < descA.Count; i++)
            {
                if (!elemA.ContainsKey(descA[i]))
                    continue;

                if(elemA[descA[i]] != elemB[descB[i]])
                    return false;
            }

                return true;
        }


        [TestMethod]
        public void SerializeToFile()
        {
            DataRepository repo = new DataRepository();

            var filler = new RandomFiller(100);
            repo.SetFiller(filler);
            repo.Fill();

            repo.SaveData("saveData");

            DataRepository repo2 = new DataRepository();
            repo2.LoadData("saveData");

            Assert.IsTrue(CheckIfSame(repo, repo2));
        }

        [TestMethod]
        public void SerializeToFileCustom()
        {
            DataRepository repo = new DataRepository();
            Book bok = new Book("kartofle", "stefan");
            Book bok2 = new Book("kartofle2", "stefan2");
            BookDescription bokDesc = new BookDescription("bla", bok);
            BookDescription bokDesc2 = new BookDescription("bla2", bok2);
            Reader red = new Reader("zenek", "cos", 666126161);
            Reader red2 = new Reader("zenek2", "cos2", 40445454);
            Borrow bor = new Borrow(red, bokDesc);
            repo.AddReader(red);
            repo.AddReader(red2);
            repo.AddBook(bok);
            repo.AddBook(bok2);
            repo.AddBookDescription(bokDesc);
            repo.AddBookDescription(bokDesc2);
            repo.AddBorrow(bor);
            repo.AddBookNumber(bokDesc, 5000);
            
            
            repo.SaveDataCustom("saveData");
            
            DataRepository repo2 = new DataRepository();
            repo2.LoadDataCustom("saveData");

            Assert.IsTrue(CheckIfSame(repo, repo2));
        }
    }
}
