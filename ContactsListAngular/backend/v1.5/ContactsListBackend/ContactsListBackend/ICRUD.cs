using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsListBackend
{
    public interface ICRUD<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Modify(T entity);
    }
}
