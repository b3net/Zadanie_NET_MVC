using System.Collections.Generic;

namespace Project.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
    }
}