using AdriStoreWeb.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using mercadopago;
using System.Configuration;
using System.Collections;
using ADRISTORE.BE;

namespace AdriStoreWeb.BLL
{

    [Serializable]
    public class CarritoCompra
    {
        private Usuario _Comprador;
        private decimal _Total;
        private List<CarritoCompraItem> _Items;

        public List<CarritoCompraItem> Items
        {
            get
            {
                if (_Items == null)
                    _Items = new List<CarritoCompraItem>();

                return _Items;
            }

            set
            {
                _Items = value;
            }
        }

        public decimal Total
        {
            get
            {
                _Total = 0;

                foreach (var item in this.Items)
                {
                    _Total += item.SubTotal;
                }

                return _Total;
            }

            set
            {
                _Total = value;
            }
        }

        public Usuario Comprador
        {
            get
            {
                return _Comprador;
            }

            set
            {
                _Comprador = value;
            }
        }

        public void CancelarTodo() {
            Items.Clear();
        }

        public decimal CalcularTotal() {
            this._Total = 0;

            foreach (var item in this.Items)
            {
                item.Calcular();
                this._Total += item.SubTotal;
            }

            return this._Total;
        }

        //Devuelve el link 
        public String GetLinkPago() {
            //Guardar el pedido
            //var auxPedido = RepoPedidos.Crear(this);

            /*MP auxMP = new MP(ConfigurationManager.AppSettings["MPToken"]);
            //MP auxMP = new MP(ConfigurationManager.AppSettings["CLIENT_ID"], ConfigurationManager.AppSettings["CLIENT_SECRET"]);
            auxMP.sandboxMode(Boolean.Parse(ConfigurationManager.AppSettings["ModoSandbox"]));
            Hashtable auxHT =RepoPedidos.CrearOrdenMPHT(auxPedido);
            String strLinkUrl=(String) ((Hashtable)auxHT["response"])["sandbox_init_point"];
            return strLinkUrl;*/
            return "<a href='#'>End of Demo!</a>";
        }
    }
}
