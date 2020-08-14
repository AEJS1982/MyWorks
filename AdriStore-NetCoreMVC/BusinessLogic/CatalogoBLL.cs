using AdriStoreWeb.BE;
using AdriStoreWeb.BE.DTOs;
using AdriStoreWeb.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ADRISTORE.BE;

namespace AdriStoreWeb.BLL
{
    public class CatalogoBLL : BaseBLL
    {
        private CatalogoDAL _CapaDatos;

        protected CatalogoDAL CapaDatos
        {
            get
            {
                if (_CapaDatos == null)
                    _CapaDatos = new CatalogoDAL();

                return _CapaDatos;
            }

            set
            {
                _CapaDatos = value;
            }
        }

        public void GuardarFoto(DTOFoto auxFoto) {
          
            var VImgData = Convert.FromBase64String(auxFoto.Blob.Remove(0, auxFoto.Blob.IndexOf(",") + 1));
            var SW = new FileStream(auxFoto.PathFoto,FileMode.Create);
            SW.Write(VImgData);
            SW.Close();
            SW.Dispose();
        }

        public void Agregar(DTOCatalogoItem auxDTO)
        {
            this.CapaDatos.Agregar(auxDTO.Item);
            GuardarFoto(auxDTO.Foto);
        }

        public void Eliminar(Catalogo entidad)
        {
            this.CapaDatos.Eliminar(entidad);
        }

        public List<Catalogo> Listar()
        {
            return this.CapaDatos.Listar();
        }

        public void Modificar(DTOCatalogoItem auxDTO)
        {
            this.CapaDatos.Modificar(auxDTO.Item);
            GuardarFoto(auxDTO.Foto);
        }

        public Catalogo ObtenerXID(long ID)
        {
            return this.CapaDatos.ObtenerXID(ID);
        }
    }
}
