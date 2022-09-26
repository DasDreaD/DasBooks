using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Books
{
    public class BookForCreation : Entity
    {
        private BookForCreation(string bookTitle, double bookPrice, int authorId, int categoryId)
        {
            BookTitle = bookTitle;
            BookPrice = bookPrice;
            AuthorId = authorId;
            CategoryId = categoryId;
        }

        private BookForCreation() { }

        public string BookTitle { get; }
        public double BookPrice { get; }
        public int AuthorId { get; }
        public int CategoryId { get; }

        public static BookForCreation Create(string bookTitle, double bookPrice, int authorId, int categoryId)
        {
            return new BookForCreation(bookTitle, bookPrice, authorId, categoryId);
        }
    }
}
