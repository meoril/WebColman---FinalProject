namespace FinalProject.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.Context.BookStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalProject.Context.BookStoreContext context)
        {
            var customers = new List<Customer>
            {
                new Customer { Age = 25, City = "Tel Aviv", Name = "Meori Lehr" },
                new Customer { Age = 24, City = "Rishon Le Tziyon", Name = "Tal Benyunes" },
                new Customer { Age = 22, City = "Jerusalem", Name = "Avi Katz" },
                new Customer { Age = 38, City = "Ashdod", Name = "Yoni Kadosh" },
                new Customer { Age = 59, City = "Beer Sheva", Name = "Liat Cohen" }
            };

            customers.ForEach(c => context.Customers.AddOrUpdate(c));
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author { Age = 45, City = "Ramat Gan", Name = "Gidi Raf" },
                new Author { Age = 68, City = "New Jersey", Name = "George R. R. Martin" },
                new Author { Age = 81, City = "Bloemfontein", Name = "J. R. R. Tolkien" }
            };

            authors.ForEach(a => context.Authors.AddOrUpdate(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book { Name = "The Lord of the Rings", NumberOfPages = 3256, Price = 100, AuthorId = 3, Customers = new List<Customer> { customers[0], customers[2], customers[4] } },
                new Book { Name = "The Fellowship of the Ring", NumberOfPages = 780, Price = 110 , AuthorId = 3, Customers = new List<Customer> { customers[0], customers[1], customers[4] } },
                new Book { Name = "The Two Towers", NumberOfPages = 840, Price = 60 , AuthorId = 3, Customers = new List<Customer> { customers[0], customers[2], customers[3] } },
                new Book { Name = "The journal of a startupist", NumberOfPages = 185, Price = 55 , AuthorId = 1, Customers = new List<Customer> { customers[0], customers[1], customers[2] } },
                new Book { Name = "The Hobbit", NumberOfPages = 240, Price = 70, AuthorId = 3, Customers = new List<Customer> { customers[0], customers[2] } },
                new Book { Name = "A Game of Thrones", NumberOfPages = 945, Price = 150, AuthorId = 2, Customers = new List<Customer> { customers[1], customers[2], customers[4] } },
                new Book { Name = "A Clash of Kings", NumberOfPages = 768, Price = 150, AuthorId = 2, Customers = new List<Customer> { customers[0], customers[2], customers[3] } },
                new Book { Name = "A Storm of Swords", NumberOfPages = 973, Price = 150, AuthorId = 2, Customers = new List<Customer> { customers[0] } }
            };

            books.ForEach(b => context.Books.AddOrUpdate(b));
            context.SaveChanges();
            
            var branches = new List<Branch>
            {
                new Branch{PlaceName="Azrieli Mall, Tel Aviv" , OpeningHours="08:00-20:00, S-T", GeoLong="34.7916200" ,GeoLat="32.0757120"},
                new Branch{PlaceName="Days City Mall, Netanya" , OpeningHours="10:00-20:00, S-F", GeoLong="34.8470303" ,GeoLat="32.2790532"},
                new Branch{PlaceName="Givatayim Mall, Givatayim" , OpeningHours="10:00-14:00  S-T", GeoLong="34.8089838" ,GeoLat="32.0662936"},
                new Branch{PlaceName="Cinema City, Rishon Le Tziyon" , OpeningHours="09:00-19:00, S-F", GeoLong="34.7698510" ,GeoLat="31.9850610"},
                new Branch{PlaceName="Big Fashion, Ashdod" , OpeningHours="09:00-19:00, S-S", GeoLong="34.6620943" ,GeoLat="31.776238"}
            };

            branches.ForEach(b => context.Branches.AddOrUpdate(b));
            context.SaveChanges();
            //foreach (Book b in context.Books)
            //{
            //    b.Author = context.Authors.Find(b.AuthorId);
            //}
        }
    }
}
