using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.Domain.Entity
{
    [Table("rentals", Schema = "public")]
    public class Rental : AbstractEntity
    {
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}