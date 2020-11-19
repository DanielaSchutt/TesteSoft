using AutoMapper;
using System.Web.Http;
using TesteSoftDesign.Data.Repository;
using TesteSoftDesign.DependenceInjection;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;
using TesteSoftDesign.Domain.Interface.Repository;
using TesteSoftDesign.Domain.Interface.Service;
using TesteSoftDesign.Service;
using TesteSoftDesign.ViewModels;
using Unity;
using Unity.Lifetime;

namespace TesteSoftDesign
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRentalRepository, RentalRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IBookService, BookService>(new HierarchicalLifetimeManager());
            container.RegisterType<IRentalService, RentalService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Rental, RentalViewModel>();
            });

            IMapper mapper = autoMapperConfig.CreateMapper();

            container.RegisterInstance(mapper);

            config.DependencyResolver = new UnityResolver(container);
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
