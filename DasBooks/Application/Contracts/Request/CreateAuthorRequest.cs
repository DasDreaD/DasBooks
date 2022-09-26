using Domain.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Request
{
    public sealed class CreateAuthorRequest
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
        //public IEnumerable<Book> Book { get; set; }
    }
}
