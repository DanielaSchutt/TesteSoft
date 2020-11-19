using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.Domain.Entity
{
    [Table("books", Schema = "public")]
    public class Book : AbstractEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int Pages { get; set; }
        [Required, MaxLength(50)]
        public string AuthorName { get; set; }
        public bool IsRented { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
}