using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nvoi.Backen.API.Repositories
{ 
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        int Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
        void SaveChanges();
       
    }
}