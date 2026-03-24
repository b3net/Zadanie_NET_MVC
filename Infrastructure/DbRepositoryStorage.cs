using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Project.Infrastructure
{
    public abstract class DbRepositoryStorage<T, TContext> : IRepository<T> 
        where T : class 
        where TContext : DbContext, new()
    {
        public virtual List<T> GetAll()
        {
            using(var ctx = new TContext())
                return ctx.Set<T>().ToList();
        }

        public virtual void Add(T item)
        {
            using(var ctx = new TContext()) {
                ctx.Set<T>().Add(item);
                ctx.SaveChanges();
            }
        }
    }
}