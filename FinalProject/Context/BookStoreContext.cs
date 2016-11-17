using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FinalProject.Context
{
    public class BookStoreContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Removes the pluralizing table name convention from the db model builder (mostly removes the 's'
            // from tables names suffix)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configuring the constraints for the db model
            modelBuilder.Entity<Book>()
                .HasRequired<Author>(b => b.Author) // book requires one author
                .WithMany(a => a.Books) // author has many books
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>()
                .HasMany<Customer>(b => b.Customers)
                .WithMany(c => c.Books)
                .Map(cb =>
                {
                    cb.MapLeftKey("BookRefId");
                    cb.MapRightKey("CustomerRefId");
                    cb.ToTable("BookCustomer");
                });
        }
    }
}