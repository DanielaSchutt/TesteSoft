using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;

namespace TesteSoftDesign.Service
{
    public class UserService : AbstractService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        public User SimpleAuthentication(User user)
        {
            return this._repository.GetUser(user);
        }
    }
}