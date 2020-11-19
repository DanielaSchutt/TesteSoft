using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Data.Context;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;

namespace TesteSoftDesign.Data.Repository
{
    public class UserRepository : AbstractRepository<User, DataContext>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context, context.Users)
        {
            this._context = context;
        }


        public User GetUser(User user)
        {
            return this._context.Users.Where(i => i.Username == user.Username && i.Password == user.Password).FirstOrDefault();
        }
    }
}