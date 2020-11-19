using System.Collections.Generic;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Domain.Interface
{
    public interface IBookRepository : IRepository<Book>
    {
        IList<Book> GetAll(string searchString);
        void Rent(Book book, Rental rental);
    }
}