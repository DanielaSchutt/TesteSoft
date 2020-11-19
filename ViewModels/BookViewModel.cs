using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSoftDesign.ViewModels
{
    public class BookViewModel : AbstractViewModel
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public string AuthorName { get; set; }
        public bool IsRented { get; set; }
    }
}