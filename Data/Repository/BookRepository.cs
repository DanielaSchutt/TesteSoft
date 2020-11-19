using System.Collections.Generic;
using System.Linq;
using TesteSoftDesign.Data.Context;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;

namespace TesteSoftDesign.Data.Repository
{
    public class BookRepository : AbstractRepository<Book, DataContext>, IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context) : base(context, context.Books)
        {
            this._context = context;
        }
        public IList<Book> GetAll(string searchString)
        {
            return this._context.Books.Where(i => i.Name.ToLower().Contains(searchString)).ToList();
        }

        public void Rent(Book book, Rental rental)
        {
            this._context.Entry(book).State = System.Data.Entity.EntityState.Modified;
            this._context.Entry(rental).State = System.Data.Entity.EntityState.Added;
            this.SaveChanges();
        }
    }
}