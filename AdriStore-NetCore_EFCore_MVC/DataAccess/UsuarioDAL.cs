using ADRISTORE.BE;
using AdriStoreWeb.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.DAL
{
    public class UsuarioDAL : DBContext, ICRUD<Usuario>
    {
        public UsuarioDAL() {
            
        }

        public byte[] ConvertirStringaBytes(String input) {
            return Encoding.ASCII.GetBytes(input);
        }

        public String HashearPassword(String Password) {
            //Hashear el password
            SHA256 Hasher = SHA256.Create();
            return Convert.ToBase64String(Hasher.ComputeHash(ConvertirStringaBytes(Password)));
        }

        public void Agregar(Usuario entidad)
        {
            entidad.Id=this.Usuario.Max(x => x.Id) + 1;
            this.Usuario.Add(entidad);
            this.SaveChanges();
        }

        public void Eliminar(Usuario entidad)
        {
            var auxObj = this.Usuario.FirstOrDefault(x => x.Id == entidad.Id);

            if (auxObj != null)
            {
                this.Usuario.Remove(auxObj);
                this.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            return this.Usuario.ToList();
        }

        public void Modificar(Usuario entidad)
        {
            var auxObj = this.Usuario.FirstOrDefault(x => x.Id == entidad.Id);

            if (auxObj != null)
            {
                this.Entry(auxObj).CurrentValues.SetValues(this.Entry(entidad).CurrentValues);
                this.SaveChanges();
            }
        }

        public Usuario ObtenerXNombre(string nombre)
        {
            var Qry = from auxObj in this.Usuario
                      where auxObj.Nombre.Equals(nombre)
                      select auxObj;

            return Qry.FirstOrDefault();
        }

        public Usuario ObtenerXID(long ID)
        {
            return this.Usuario.Where(x => x.Id==ID).FirstOrDefault();
        }
    }
}
