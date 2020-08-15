using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BE.DTOs
{
    public class DTOCatalogoListadoItem
    {
        public long ID { get; set; }
        public String Nombre { get; set; }
        public String TipoItem { get; set; }
        public bool Habilitado { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaAlta { get; set; }
        public String ImagenURL { get; set; }
    }
}
