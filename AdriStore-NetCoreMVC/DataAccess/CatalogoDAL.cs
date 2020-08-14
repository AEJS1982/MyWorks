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
    public class CatalogoDAL : DBContext, ICRUD<Catalogo>
    {
        public CatalogoDAL() {
           
        }

        public void Agregar(Catalogo entidad)
        {
            entidad.Id = this.Catalogo.Max(x => x.Id) + 1;
            this.Catalogo.Add(entidad);
            this.SaveChanges();
        }

        public void Eliminar(Catalogo entidad)
        {
            var auxObj = this.Catalogo.FirstOrDefault(x => x.Id==entidad.Id);

            if (auxObj != null)
            {
                this.Catalogo.Remove(auxObj);
                this.SaveChanges();
            }
        }

        public List<Catalogo> Listar()
        {
            return this.Catalogo.Include("Rubro").ToList();
        }

        public void Modificar(Catalogo entidad)
        {

            var auxObj = this.Catalogo.FirstOrDefault(x => x.Id==entidad.Id);

            if (auxObj != null)
            {
                this.Entry(auxObj).CurrentValues.SetValues(this.Entry(entidad).CurrentValues);
                this.SaveChanges();
            }
        }

        public Catalogo ObtenerXID(long ID)
        {
            var auxObj = this.Catalogo.Where(x => x.Id == ID).Include("Rubro").FirstOrDefault();
            return auxObj;
        }
    }
}
