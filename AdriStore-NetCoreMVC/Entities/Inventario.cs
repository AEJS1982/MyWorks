using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADRISTORE.BE
{
    [Serializable]
    public partial class Inventario
    {
        public long Id { get; set; }
        public long? CantidadDisponible { get; set; }
        public bool Habilitado { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\s]*$")]
        public string Comentario { get; set; }
        public DateTime FechaAlta { get; set; }
        public long? CatalogoId { get; set; }

        public Catalogo Catalogo { get; set; }
    }
}
