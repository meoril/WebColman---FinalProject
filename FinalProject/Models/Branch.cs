using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string OpeningHours { get; set; }
        public string GeoLong { get; set; }
        public string GeoLat { get; set; }
    }
}