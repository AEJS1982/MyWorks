using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADRISTORE.BE
{
    [Serializable]
    public partial class Catalogo
    {
        public Catalogo()
        {
            Inventario = new HashSet<Inventario>();
        }

        public long Id { get; set; }
        [RegularExpression(@"^[A-Za-z\s0-9]*$")]
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaAlta { get; set; }
        public long? RubroId { get; set; }
        public RubroCatalogo Rubro { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
    }
}
