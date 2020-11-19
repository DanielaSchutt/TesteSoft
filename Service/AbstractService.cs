using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;
using TesteSoftDesign.Domain.Interface;

namespace TesteSoftDesign.Service
{
    public abstract class AbstractService<TEntity> where TEntity : AbstractEntity
    {
        private readonly IRepository<TEntity> _repository;

        public AbstractService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public virtual IList<TEntity> GetAll()
        {
            return this._repository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return this._repository.GetById(id);
        }

        public virtual void Add(TEntity obj)
        {
            this._repository.Insert(obj);
        }

        public virtual TEntity Update(TEntity obj)
        {
            return this._repository.Update(obj);
        }

        public virtual void Remove(int id)
        {
            this._repository.Remove(id);
        }
    }

}