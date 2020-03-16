using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class MovieTable
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
    }
}
