using System;
using System.Collections.Generic;

namespace BrandAPP.DBLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T FindByName(string name);
        void Create(T item);
        void Update(int id, T item);
        void Delete(int id);
        bool AnyId(int id);
    }
}
