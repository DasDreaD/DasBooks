using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Persistence.DbContexts.DasBooks
{
    public partial class DasBooksDbContext : DbContext
    {
        public DasBooksDbContext()
        {
        }

        public DasBooksDbContext(DbContextOptions<DasBooksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookCategories> BookCategories { get; set; }
        public virtual DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK_Authors_AuthorId");

                entity.Property(e => e.About).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);
            });

            modelBuilder.Entity<BookCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_BookCategories_CategoryId");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__BookCate__8517B2E0C1F43AFC")
                    .IsUnique();

                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK_Books_BookId");

                entity.Property(e => e.BookTitle).IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_AuthorId_Authors_AuthorId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_CategoryId_BookCategories_CategoryId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
