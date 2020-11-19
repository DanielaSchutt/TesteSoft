using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.Domain.Entity
{
    [Table("users", Schema = "public")]
    public class User : AbstractEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(300)]
        public string Password { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}