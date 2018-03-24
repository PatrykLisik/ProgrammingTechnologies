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
        BookDescription Description;

        public Book(BookDescription description)
        {
            Description = description;
        }
        public Book(string title, string author)
        {
            Description = new BookDescription(title,author);
        }
    }
}
