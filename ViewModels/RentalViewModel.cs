using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.ViewModels
{
    public class RentalViewModel
    {
        public BookViewModel Book { get; set; }
        public int BookId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public UserViewModel User { get; set; }
        public int UserId { get; set; }
    }
}