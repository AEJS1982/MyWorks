using ADRISTORE.BE;
using AdriStoreWeb.BE;
using AdriStoreWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdriStoreWeb.BLL
{
    public class ClienteBLL : BaseBLL, ICRUD<Cliente>
    {
        private ClienteDAL _Repo;

        public ClienteDAL Repo
        {
            get
            {
                if (_Repo == null)
                    _Repo = new ClienteDAL();
                return _Repo;
            }

            set { _Repo = value; }
        }

        public void Agregar(Cliente entidad)
        {
            this.Repo.Agregar(entidad);   
        }

        public void Eliminar(Cliente entidad)
        {
            this.Repo.Eliminar(entidad);
        }

        public List<Cliente> Listar()
        {
            return this.Repo.Listar();
        }

        public void Modificar(Cliente entidad)
        {
            this.Repo.Modificar(entidad);
        }

        public Cliente ObtenerXID(long ID)
        {
            return this.Repo.ObtenerXID(ID);
        }
    }
}
