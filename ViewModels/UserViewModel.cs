using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.ViewModels
{
    public class UserViewModel : AbstractViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
        public List<RentalViewModel> Rentals { get; set; }
    }
}