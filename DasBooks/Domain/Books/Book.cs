using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Books
{
    public class Book : Entity
    {
        public Book(string bookTitle, double bookPrice, string categoryName, string authorName)
        {
            BookTitle = bookTitle;
            BookPrice = bookPrice;
            CategoryName = categoryName;
            AuthorName = authorName;
        }

        private Book() { }

        public string BookTitle { get; private set; }
        public double BookPrice { get; private set; }
        public string CategoryName { get; private set; }
        public string AuthorName { get; private set; }
    }
}
