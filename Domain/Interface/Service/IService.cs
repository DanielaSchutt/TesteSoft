using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Domain.Interface
{
    public interface IService<T> where T : AbstractEntity
    {
        void Add(T obj);

        T Update(T obj);

        void Remove(int obj);

        T GetById(int id);

        IList<T> GetAll();
    }
}