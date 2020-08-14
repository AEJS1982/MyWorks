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
    public class RubroCatalogoBLL : BaseBLL, ICRUD<RubroCatalogo>
    {
        private RubroCatalogoDAL _CapaDatos;

        protected RubroCatalogoDAL CapaDatos
        {
            get
            {
                if (_CapaDatos == null)
                    _CapaDatos = new RubroCatalogoDAL();

                return _CapaDatos;
            }

            set
            {
                _CapaDatos = value;
            }
        }

        public void Agregar(RubroCatalogo entidad)
        {
            this.CapaDatos.Agregar(entidad);
        }

        public void Eliminar(RubroCatalogo entidad)
        {
            this.CapaDatos.Eliminar(entidad);
        }

        public List<RubroCatalogo> Listar()
        {
            return this.CapaDatos.Listar();
        }

        public void Modificar(RubroCatalogo entidad)
        {
            this.CapaDatos.Modificar(entidad);
        }

        public RubroCatalogo ObtenerXID(long ID)
        {
            return this.CapaDatos.ObtenerXID(ID);
        }
    }
}
