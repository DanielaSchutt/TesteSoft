using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;
using TesteSoftDesign.ViewModels;

namespace TesteSoftDesign.WebAPI.ControllersApi
{
    public class BookController : AbstractController<Book, BookViewModel>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService service, IMapper mapper) : base(service, mapper)
        {
            _bookService = service;
            _mapper = mapper;
        }
        // GET: api/Book
        public IHttpActionResult GetAll([FromUri]string searchString)
        {
            var list = this._bookService.GetAll(searchString);
            var listVM = this._mapper.Map<List<BookViewModel>>(list);
            return Ok(listVM);
        }

        public  IHttpActionResult Put(int id, [FromUri] int userId)
        {
            this._bookService.Rent(id, userId);
            return Ok();
        }
    }
}
