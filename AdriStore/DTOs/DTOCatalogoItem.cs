using ADRISTORE.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BE.DTOs
{
    public class DTOCatalogoItem
    {
        public Catalogo Item { get; set; }
        public DTOFoto Foto { get; set; }
    }
}
