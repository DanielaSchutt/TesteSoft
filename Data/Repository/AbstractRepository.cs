using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TesteSoftDesign.Domain.Entity;

namespace TesteSoftDesign.Data.Repository
{
    public abstract class AbstractRepository<TEntity, TContext> : IDisposable where TEntity : AbstractEntity where TContext : DbContext
    {
        private readonly TContext Context;
        private readonly DbSet<TEntity> DbSet;

        public AbstractRepository(TContext context, DbSet<TEntity> dbSet)
        {
            this.DbSet = dbSet;
            this.Context = context;
        }

        public virtual void Insert(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Added;
            this.SaveChanges();
        }
        public virtual IList<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return this.DbSet.SingleOrDefault(i => i.Id == id);
        }

        public virtual TEntity Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
            return obj;
        }

        public virtual void Remove(int id)
        {
            var obj = DbSet.SingleOrDefault(i => i.Id == id);

            if (obj == null)
                throw new Exception("Id não encontrado");

            DbSet.Remove(obj);
            this.SaveChanges();

        }

        public int SaveChanges()
        {
            var response = 0;
            using (var transaction = Context.Database.BeginTransaction())
            {
                response = Context.SaveChanges();
                transaction.Commit();
            }

            return response;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}