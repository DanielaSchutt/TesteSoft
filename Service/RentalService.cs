using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface.Repository;
using TesteSoftDesign.Domain.Interface.Service;

namespace TesteSoftDesign.Service
{
    public class RentalService : AbstractService<Rental>, IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}