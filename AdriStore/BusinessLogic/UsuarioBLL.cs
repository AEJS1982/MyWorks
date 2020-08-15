using ADRISTORE.BE;
using AdriStoreWeb.BE;
using AdriStoreWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BLL
{
    public class UsuarioBLL : BaseBLL, ICRUD<Usuario>
    {
        private UsuarioDAL _CapaDatos;

        public UsuarioDAL CapaDatos
        {
            get
            {
                if (_CapaDatos == null)
                    _CapaDatos = new UsuarioDAL();

                return _CapaDatos;
            }

            set
            {
                _CapaDatos = value;
            }
        }

        public Usuario ObtenerXNombre(string nombre)
        {
            return this.CapaDatos.ObtenerXNombre(nombre);
        }

        public void Agregar(Usuario entidad)
        {
            this.CapaDatos.Agregar(entidad);
        }

        public void Eliminar(Usuario entidad)
        {
            this.CapaDatos.Eliminar(entidad);
        }

        public List<Usuario> Listar()
        {
            return this.CapaDatos.Listar();
        }

        public void Modificar(Usuario entidad)
        {
            this.CapaDatos.Modificar(entidad);
        }

        public Usuario ObtenerXID(long ID)
        {
            return this.CapaDatos.ObtenerXID(ID);
        }

        public List<Usuario> ObtenerClientes() {
            return this.CapaDatos.Listar().Where(x => x.TipoUsuario == "C").ToList();

        }

        public void AgregarCliente(Usuario auxCliente) {
            auxCliente.TipoUsuario = "C";
            this.CapaDatos.Agregar(auxCliente);
        }

        public void ModificarCliente(Usuario auxCliente) {
            auxCliente.TipoUsuario = "C";
            this.CapaDatos.Modificar(auxCliente);

        }

        public bool isLoginOK(Usuario unUsuario) {
            var Repo = new UsuarioDAL();

            var auxObj = Repo.ObtenerXNombre(unUsuario.Nombre);

            if (auxObj != null)
            {
                
                //User exists, check password
                /*var tmpPw = auxObj.Password.Remove(0, 1).Remove(auxObj.Password.Length - 2, 1);
                
                if (Repo.HashearPassword(unUsuario.Password).Equals(tmpPw)) {
                    unUsuario = auxObj;
                    return true;
                }
                */

                if (unUsuario.Password.Equals(auxObj.Password))
                {
                    unUsuario = auxObj;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
