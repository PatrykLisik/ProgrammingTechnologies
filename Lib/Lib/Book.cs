﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //katalog
    public class Book
    {
        string Title;
        string Author;

        public Book(string title, string author)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public override string ToString()
        {
           return String.Format("Book: {0} by {1}", Title, Author);
        }
    }
}
