using ADRISTORE.BE;
using AdriStoreWeb.BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.DAL
{
    public class InventarioDAL : DBContext, ICRUD<Inventario>
    {
        public InventarioDAL() {
        }

        public void Agregar(Inventario entidad)
        {
            entidad.Id=this.Inventario.Max(x => x.Id) + 1;
            this.Inventario.Add(entidad);
            this.SaveChanges();
        }

        public void Eliminar(Inventario entidad)
        {
            var auxObj = this.Inventario.FirstOrDefault(x => x.Id == entidad.Id);

            if (auxObj != null)
            {
                this.Inventario.Remove(entidad);
                this.SaveChanges();
            }
        }

        public List<Inventario> Listar()
        {
            var Qry = this.Inventario.Include(x => x.Catalogo.Rubro).ToList();
            var result= Qry.ToList();
            return result;
        }

        public void Modificar(Inventario entidad)
        {
            var auxObj = this.Inventario.FirstOrDefault(x => x.Id == entidad.Id);

            if (auxObj != null)
            {
                this.Entry(auxObj).CurrentValues.SetValues(this.Entry(entidad).CurrentValues);
                this.SaveChanges();
            }
        }

        public Inventario ObtenerXID(long ID)
        {
            var Qry = this.Inventario.Where(x => x.Id==ID).Include(x => x.Catalogo.Rubro).ToList();
            return Qry.FirstOrDefault(); 
        }
    }
}
