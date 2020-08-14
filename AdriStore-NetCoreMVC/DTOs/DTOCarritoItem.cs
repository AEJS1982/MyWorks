using ADRISTORE.BE;
using System;

namespace ADRISTORE.DTOs
{
    [Serializable]
    public class DTOCarritoItem
    {
        private int _ID;
        private long _InventarioID;
        private int _Cantidad;
        private int _Precio;
        private decimal _SubTotal;
        private Inventario _ItemInventario;
        private String _SessionID;

        public long InventarioID { get => _InventarioID; set => _InventarioID = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int Precio { get => _Precio; set => _Precio = value; }
        public decimal SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public Inventario ItemInventario { get => _ItemInventario; set => _ItemInventario = value; }
        public string SessionID { get => _SessionID; set => _SessionID = value; }
        public int ID { get => _ID; set => _ID = value; }

        public decimal Calcular() {
            if (this.ItemInventario != null)
                if (this.ItemInventario.Catalogo != null)
                    this.SubTotal = this.ItemInventario.Catalogo.Precio * this.Cantidad;

            return this.SubTotal;
        }
    }
}