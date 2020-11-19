using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TesteSoftDesign.Authentication;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;
using TesteSoftDesign.ViewModels;

namespace TesteSoftDesign.WebAPI.ControllersApi
{
    public class LoginController : AbstractController<User, UserViewModel>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IUserService service, IMapper mapper) : base(service, mapper)
        {
            _userService = service;
            _mapper = mapper;
        }


        public override IHttpActionResult Post(User user)
        {
            var authenticated = this._userService.SimpleAuthentication(user);
            if (authenticated!= null)
            {
                
                return Ok(new
                {
                    id = authenticated.Id,
                    token = TokenProvider.GetToken()
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}