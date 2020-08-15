using ADRISTORE.BE;
using AdriStoreWeb.BE;
using AdriStoreWeb.BE.DTOs;
using AdriStoreWeb.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BLL
{
    public class PedidosBLL : BaseBLL, ICRUD<PedidoCab>
    {
        private PedidosDAL _CapaDatos;

        protected PedidosDAL CapaDatos
        {
            get
            {
                if (_CapaDatos == null)
                    _CapaDatos = new PedidosDAL();
                return _CapaDatos;
            }

            set
            {
                _CapaDatos = value;
            }
        }

        public void Agregar(PedidoCab entidad)
        {
            this.CapaDatos.Agregar(entidad);
        }

        public void Eliminar(PedidoCab entidad)
        {
            this.CapaDatos.Eliminar(entidad);
        }

        public List<PedidoCab> Listar()
        {
            return this.CapaDatos.Listar();
        }

        public List<PedidoCab> Buscar(string estadoPedido, DateTime fechaInicial, DateTime fechaFinal)
        {
            return this.CapaDatos.Buscar(estadoPedido, fechaInicial, fechaFinal);
        }

        public void Modificar(PedidoCab entidad)
        {
            this.CapaDatos.Modificar(entidad);
        }

        public PedidoCab ObtenerXID(long ID)
        {
            return this.CapaDatos.ObtenerXID(ID);
        }

        public PedidoCab Crear(CarritoCompra carritoCompra)
        {
            var auxPedido = new PedidoCab();
            auxPedido.FechaAlta = DateTime.Now;
            auxPedido.Estado = "I";
            auxPedido.ClienteId = carritoCompra.Comprador.Id;

            foreach (var item in carritoCompra.Items)
            {
                var auxPedidoDET = new PedidoDet();
                auxPedidoDET.Cantidad = item.Cantidad;
                auxPedidoDET.InventarioId= item.ItemInventario.Id;
                auxPedido.PedidoDet.Add(auxPedidoDET);
            }

            return auxPedido;
        }

        public String CrearOrdenMP(PedidoCab auxPedido) {
            //Ejemplo:
            //var JSONPedido = "{\"items\":[{\"title\":\"sdk-dotnet\",\"quantity\":1,\"currency_id\":\"ARS\",\"unit_price\":10.5}]}";

            StringBuilder SB = new StringBuilder();
            SB.Append("{\"items\":[");

            var Detalles = auxPedido.PedidoDet.ToList();

            SB.Append("]}");
            var StrSalida = SB.ToString().Trim();
            return StrSalida;
        }

        public Hashtable CrearOrdenMPHT(PedidoCab auxPedido)
        {
            var auxHT = new Hashtable();
            var ItemList = new ArrayList();

            foreach (PedidoDet item in auxPedido.PedidoDet)
            {
                var auxDTO = new DTOMercadoPagoItem();
                auxDTO.currency_id = "ARS";
                auxDTO.quantity = item.Cantidad.ToString();
                /*auxDTO.title = item.ItemInventario.Catalogo.Nombre;
                auxDTO.unit_price = item.ItemInventario.Catalogo.Precio.ToString();*/

                ItemList.Add(auxDTO);
            }

            auxHT.Add("items", ItemList);

            return auxHT;
        }
    }
}
