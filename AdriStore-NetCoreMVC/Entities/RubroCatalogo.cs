using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADRISTORE.BE
{
    [Serializable]
    public partial class RubroCatalogo
    {
        public RubroCatalogo()
        {
            Catalogo = new HashSet<Catalogo>();
        }

        public long Id { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\s]*$")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\s-.,]*$")]
        public string Comentario { get; set; }
        public long? Habilitado { get; set; }
        public DateTime FechaAlta { get; set; }
        public ICollection<Catalogo> Catalogo { get; set; }
    }
}
