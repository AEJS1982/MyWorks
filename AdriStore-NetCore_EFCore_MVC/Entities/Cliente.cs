using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADRISTORE.BE
{
    public partial class Cliente
    {
        public long Id { get; set; }
        [RegularExpression("^[A-Za-z]*$")]
        public string Nombre { get; set; }
        [RegularExpression("^[A-Za-z]*$")]
        public string Apellido { get; set; }
        public bool Habilitado { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\s]*$")]
        public string DireccionEntrega { get; set; }
        [RegularExpression("^[0-9-]*$")]
        public string TelefonoContacto { get; set; }
        [RegularExpression("^[0-9]*$")]
        public string Dni { get; set; }
        public DateTime FechaAlta { get; set; }
        [RegularExpression(@"^([A-Za-z0-9-.]*)@([A-Za-z0-9-]*).([A-Za-z]*)$")]
        public string Email { get; set; }

        public ICollection<PedidoCab> Pedidos { get; set; }
    }
}
