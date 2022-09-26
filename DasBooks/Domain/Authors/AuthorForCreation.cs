using System;

namespace Domain.Authors
{
    public class AuthorForCreation
    {
        public AuthorForCreation(string firstName, string middleName, string lastName, DateTime dateOfBirth, string about)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            About = about;
        }

        private AuthorForCreation() { }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; }
        public string About { get; set; }
        //public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
