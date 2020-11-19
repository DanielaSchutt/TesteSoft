using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Domain.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(User user);
    }
}