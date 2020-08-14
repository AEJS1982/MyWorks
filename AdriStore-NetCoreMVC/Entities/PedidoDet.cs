using System;
using System.Collections.Generic;

namespace ADRISTORE.BE
{
    public partial class PedidoDet
    {
        public long Id { get; set; }
        public long? InventarioId { get; set; }
        public long? Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public long? PedidoCabId { get; set; }

        public PedidoCab PedidoCab { get; set; }
    }
}
