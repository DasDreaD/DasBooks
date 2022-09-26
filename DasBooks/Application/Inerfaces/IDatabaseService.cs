using Domain.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Inerfaces
{
    interface IDatabaseService
    {
        IEnumerable<Book> Customers { get; set; }
    }
}
