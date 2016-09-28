using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Book
    {
        public Book()
        {
            this.Customers = new HashSet<Customer>();
        }


        [Key]
        public long Id { get; set; }

        [Display(Name = "Book Name")]
        public string Name { get; set; }

        [Display(Name = "Number Of Pages")]
        public int NumberOfPages { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}