using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADRISTORE.BE;
using AdriStoreWeb.BE;


namespace AdriStoreWeb.DAL
{
    public class ClienteDAL : DBContext, ICRUD<Cliente>
    {
        public ClienteDAL() {
        }

        public void Agregar(Cliente entidad)
        {
            entidad.Id = this.Cliente.Max(x => x.Id) + 1;
            this.Cliente.Add(entidad);
            this.SaveChanges();
        }

        public void Eliminar(Cliente entidad)
        {
            var auxObj = this.Cliente.Where(x => x.Id == entidad.Id).FirstOrDefault();

            if (auxObj != null)
            {
                this.Cliente.Remove(auxObj);
                this.SaveChanges();
            }
        }

        public List<Cliente> Listar()
        {
            return this.Cliente.ToList();
        }

        public void Modificar(Cliente entidad)
        {

            //Reemplazar los valores
            this.Cliente.Update(entidad);
            this.SaveChanges();
        }

        public Cliente ObtenerXID(long ID)
        {
            return this.Cliente.Where(x => x.Id == ID).FirstOrDefault();
        }
    }
}
