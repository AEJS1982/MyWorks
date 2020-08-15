using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADRISTORE.BE
{
    public interface ICRUD<T>
    {
        void Agregar(T entity);
        void Eliminar(T entity);
        void Modificar(T entity);
        List<T> Listar();
    }
}
