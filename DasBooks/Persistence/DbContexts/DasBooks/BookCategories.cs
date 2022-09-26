using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Persistence.DbContexts.DasBooks
{
    [Table("BookCategories", Schema = "Front")]
    public partial class BookCategories
    {
        public BookCategories()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Books> Books { get; set; }
    }
}
