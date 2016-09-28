using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class CustomerBook
    {
        [Key]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long BookId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}