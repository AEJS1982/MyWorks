using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADRISTORE.BE;
using AdriStoreWeb.BE;

namespace AdriStoreWeb.BLL
{
    [Serializable]
    public class CarritoCompraItem
    {
        private Inventario _ItemInventario;
        private int _Cantidad=0;
        private decimal _SubTotal=0;

        
        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public decimal SubTotal
        {
            get
            {
                return Math.Round(_SubTotal,2);
            }

            set
            {
                _SubTotal = value;
            }
        }

        public Inventario ItemInventario
        {
            get
            {
                return _ItemInventario;
            }

            set
            {
                _ItemInventario = value;
            }
        }

        public void Calcular()
        {
            this.SubTotal =this.Cantidad * this.ItemInventario.Catalogo.Precio;
        }
    }
}
