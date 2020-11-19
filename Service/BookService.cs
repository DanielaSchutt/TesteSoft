using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;
using TesteSoftDesign.Domain.Interface.Repository;
using TesteSoftDesign.Domain.Interface.Service;

namespace TesteSoftDesign.Service
{
    public class BookService : AbstractService<Book>, IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IRentalService _rentalService;

        public BookService(IBookRepository repository, IRentalService rentalService) : base(repository)
        {
            this._repository = repository;
            this._rentalService = rentalService;
        }
        public IList<Book> GetAll(string stringSearch)
        {
            return this._repository.GetAll(stringSearch);
        }

        public Book Rent(int id, int userId)
        {
            var obj = this._repository.GetById(id);
            obj.IsRented = true;

            var newRental = new Rental();
            newRental.BookId = id;
            newRental.UserId = userId;
            newRental.InitialDate = DateTime.Now;
            newRental.ExpiryDate = DateTime.Now.AddDays(15);

            this._repository.Rent(obj, newRental);

            return obj;
        }

    }
}