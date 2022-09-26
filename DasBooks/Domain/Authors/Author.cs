using Domain.Common;
using System;

namespace Domain.Authors
{
    public class Author : Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
    }
}
