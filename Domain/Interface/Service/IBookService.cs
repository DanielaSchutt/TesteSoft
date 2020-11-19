using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Domain.Interface
{
    public interface IBookService : IService<Book>
    {
        IList<Book> GetAll(string searchString);
        Book Rent(int id, int userId);
    }
}