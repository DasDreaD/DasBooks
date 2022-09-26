using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Persistence.DbContexts.DasBooks
{
    [Table("Authors", Schema = "Front")]
    public partial class Authors
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(1000)]
        public string About { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Books> Books { get; set; }
    }
}
