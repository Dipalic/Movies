using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MovieApp.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
    }
}
