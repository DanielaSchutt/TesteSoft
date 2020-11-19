using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Data.Context;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface.Repository;

namespace TesteSoftDesign.Data.Repository
{
    public class RentalRepository : AbstractRepository<Rental, DataContext>, IRentalRepository
    {
        private readonly DataContext _context;
        public RentalRepository(DataContext context) : base(context, context.Rental)
        {
            this._context = context;
        }
    }
}