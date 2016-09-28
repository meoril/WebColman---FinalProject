using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}