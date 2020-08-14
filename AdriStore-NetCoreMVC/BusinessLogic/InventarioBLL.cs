using ADRISTORE.BE;
using AdriStoreWeb.DAL;
using System;
using System.Collections.Generic;

namespace AdriStoreWeb.BLL
{
    public class InventarioBLL : BaseBLL, ICRUD<Inventario>
    {
        private InventarioDAL _CapaDatos;

        protected InventarioDAL CapaDatos
        {
            get
            {
                if (_CapaDatos == null)
                    _CapaDatos = new InventarioDAL();

                return _CapaDatos;
            }

            set
            {
                _CapaDatos = value;
            }
        }

        public void Agregar(Inventario entidad)
        {
            this.CapaDatos.Agregar(entidad);
        }

        public void Eliminar(Inventario entidad)
        {
            this.CapaDatos.Eliminar(entidad);
        }

        public List<Inventario> Listar()
        {
            return this.CapaDatos.Listar();
        }

        public void Modificar(Inventario entidad)
        {
            this.CapaDatos.Modificar(entidad);
        }

        public Inventario ObtenerXID(long ID)
        {
            return this.CapaDatos.ObtenerXID(ID);
        }

        public void Eliminar(long ID)
        {
            var auxObj = this.CapaDatos.ObtenerXID(ID);
            this.CapaDatos.Eliminar(auxObj);
        }
    }
}
