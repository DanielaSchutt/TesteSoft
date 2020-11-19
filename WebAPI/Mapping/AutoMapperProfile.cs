using AutoMapper;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.ViewModels;

namespace TesteSoftDesign.WebAPI.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<User, UserViewModel>();
           CreateMap<Book, BookViewModel>();
           CreateMap<Rental, RentalViewModel>();
        }
    }
}