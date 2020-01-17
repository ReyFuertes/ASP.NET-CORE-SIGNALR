using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Services
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        //public virtual DbSet<Author> Authors { get; set; }
        //public virtual DbSet<Book> Books { get; set; }
        //public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        //public virtual DbSet<BookCategory> BookCategories { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Country> Countries { get; set; }
        //public virtual DbSet<Review> Reviews { get; set; }
        //public virtual DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            ////establish the entity for bookcategory and the keys for many to many relationships
            //modelBuilder.Entity<BookCategory>()
            //    .HasKey(bc => new { bc.BookId, bc.CategoryId });
            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(b => b.Book)
            //    .WithMany(bc => bc.BookCategories)
            //    .HasForeignKey(b => b.BookId);
            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(c => c.Category)
            //    .WithMany(bc => bc.BookCategories)
            //    .HasForeignKey(c => c.CategoryId);

            ////establish the entity for book author and the keys for many to many relationships
            //modelBuilder.Entity<BookAuthor>()
            //    .HasKey(ba => new { ba.BookId, ba.AuthorId });
            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(a => a.Author)
            //    .WithMany(ba => ba.BookAuthors)
            //    .HasForeignKey(a => a.AuthorId);
            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(b => b.Book)
            //    .WithMany(ba => ba.BookAuthors)
            //    .HasForeignKey(b => b.BookId);
        }
    }
}
