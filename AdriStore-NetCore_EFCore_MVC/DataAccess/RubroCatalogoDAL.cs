using ADRISTORE.BE;
using AdriStoreWeb.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.DAL
{
    public class RubroCatalogoDAL : DBContext, ICRUD<RubroCatalogo>
    {
        public RubroCatalogoDAL() {
        }

        public void Agregar(RubroCatalogo entidad)
        {
            entidad.FechaAlta = DateTime.Now;
            entidad.Id=this.RubroCatalogo.Max(x => x.Id)+1;
            this.RubroCatalogo.Add(entidad);
            this.SaveChanges();
        }

        public void Eliminar(RubroCatalogo entidad)
        {
            var auxObj = this.RubroCatalogo.FirstOrDefault(x => x.Id == entidad.Id);

            if (auxObj != null)
            {
                this.RubroCatalogo.Remove(auxObj);
                this.SaveChanges();
            }
        }

        public List<RubroCatalogo> Listar()
        {
            return this.RubroCatalogo.ToList();
        }

        public void Modificar(RubroCatalogo entidad)
        {
            var auxObj = this.ObtenerXID(entidad.Id);

            if (auxObj != null)
            {
                this.Entry(auxObj).CurrentValues.SetValues(this.Entry(entidad).CurrentValues);
                this.SaveChanges();
            }
        }

        public RubroCatalogo ObtenerXID(long ID)
        {
            return this.RubroCatalogo.Where(x => x.Id == ID).FirstOrDefault();
        }
    }
}
