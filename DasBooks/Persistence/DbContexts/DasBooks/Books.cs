using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Persistence.DbContexts.DasBooks
{
    [Table("Books", Schema = "Front")]
    public partial class Books
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(200)]
        public string BookTitle { get; set; }
        [Column(TypeName = "numeric(7, 2)")]
        public decimal BookPrice { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty(nameof(Authors.Books))]
        public virtual Authors Author { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(BookCategories.Books))]
        public virtual BookCategories Category { get; set; }
    }
}
