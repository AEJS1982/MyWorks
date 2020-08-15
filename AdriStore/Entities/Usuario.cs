using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADRISTORE.BE
{
    [Serializable]
    public partial class Usuario
    {
        public long Id { get; set; }
        [RegularExpression(@"^[A-Za-z\s]*$")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[A-Za-z\s]*$")]
        public string Password { get; set; }
        public bool Habilitado { get; set; }
        [RegularExpression(@"^[A-Z]{1}$")]
        public string TipoUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        [RegularExpression(@"^[A-Z]{1}$")]
        public string Estado { get; set; }

        public string Dni { get; set; }
        [RegularExpression(@"^([A-Za-z0-9-.]*)@([A-Za-z0-9-]*).([A-Za-z]*)$")]
        public string Email { get; set; }
    }
}
