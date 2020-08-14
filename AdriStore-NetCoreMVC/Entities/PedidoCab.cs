using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADRISTORE.BE
{
    public partial class PedidoCab
    {
        public PedidoCab()
        {
            PedidoDet = new HashSet<PedidoDet>();
        }

        public long Id { get; set; }
        public long? ClienteId { get; set; }
        public Cliente cliente { get; set; }
        public DateTime FechaAlta { get; set; }
        [RegularExpression(@"^[A-Z]{1}$")]
        public string Estado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal Total { get; set; }

        public ICollection<PedidoDet> PedidoDet { get; set; }
    }
}
