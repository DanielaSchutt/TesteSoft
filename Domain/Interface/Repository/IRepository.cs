using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Domain.Interface
{
    public interface IRepository<T> : IDisposable where T : AbstractEntity
    {
        void Insert(T obj);

        T Update(T obj);

        void Remove(int id);

        T GetById(int id);

        IList<T> GetAll();


    }
}