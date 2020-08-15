using ADRISTORE.BE;
using ADRISTORE.DTOs;
using AdriStoreWeb.BE;
using AdriStoreWeb.BLL;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AdriStoreWeb.Models
{
    public class SessionCarrito
    {
        public static IHttpContextAccessor accessor;

        public ISession Session {
            get {
                return accessor.HttpContext.Session;
            }
        }

        private DTOCarritoCompra _Compra;

        private DTOCarritoCompra Compra
        {
            get
            {
                if (_Compra==null)
                {
                    if (Session.GetString("CarritoCompra") == null)
                    {
                        _Compra = new DTOCarritoCompra();
                        Session.SetString("CarritoCompra", JsonConvert.SerializeObject(_Compra));
                    }
                    else
                    {
                        if (Session.GetString("CarritoCompra") != null)
                            _Compra = JsonConvert.DeserializeObject<DTOCarritoCompra>(Session.GetString("CarritoCompra"));

                    }
                }

                return _Compra;
            }

            set
            {
                _Compra = value; 
                Session.Remove("CarritoCompra");
                Session.SetString("CarritoCompra", JsonConvert.SerializeObject(_Compra));
            }
        }

        public String GetUsuarioLogueado()
        {
            if (Session == null)
                return String.Empty;

            var usuarioLogueado = Session.GetString("UsuarioLogueadoNombre");
            if (usuarioLogueado != null)
                return Session.GetString("UsuarioLogueadoNombre");
            else
                return String.Empty;

        }

        public DTOCarritoCompra ObtenerCompra()
        {
            return this.Compra;
        }

        private void Guardar() {

            Session.SetString("CarritoCompra",JsonConvert.SerializeObject(_Compra));
        }

        public void AgregarItem(DTOCarritoItem unItem) {
            var InventarioRepo = new InventarioBLL();
            unItem.ItemInventario = InventarioRepo.ObtenerXID(unItem.ItemInventario.Id);
            unItem.SessionID = Session.Id;
            Compra.Items.Add(unItem);
            Guardar();
        }

        public void QuitarItem(DTOCarritoItem unItem) {
            var auxItem = Compra.Items.Where(x => x.ItemInventario.Id == unItem.ItemInventario.Id).FirstOrDefault();

            if (auxItem != null)
            {
                Compra.Items.Remove(auxItem);
                Guardar();
            }
        }

        public void VaciarCarrito() {
            Compra.Items.Clear();
        }

       

        public DTOCarritoCompra getCarrito()
        {
            this.Compra.SubTotal = 0;

            foreach (var item in this.Compra.Items)
            {
                item.Calcular();
                this.Compra.SubTotal += item.SubTotal;
            }

            return this.Compra;
        }

        public void setCarrito(DTOCarritoCompra auxCarrito)
        {
            _Compra = auxCarrito;
            Session.SetString("CarritoCompra", JsonConvert.SerializeObject(_Compra));
        }

        public void GenerarPedido()
        {
            var PedidosRepo = new PedidosBLL();
            var auxPedido = new PedidoCab();
            auxPedido.FechaAlta = DateTime.Now;
            auxPedido.Estado = "I";

            var clienteLogueado =JsonConvert.DeserializeObject<Cliente>(Session.GetString("UsuarioLogueado"));
            
            var auxCliente = new ClienteBLL().Listar().FirstOrDefault(x => x.Dni == clienteLogueado.Dni);
            auxPedido.ClienteId = auxCliente.Id;

            foreach (var item in this.Compra.Items)
            {
                var auxPedidoDet = new PedidoDet();
                auxPedidoDet.Cantidad = item.Cantidad;
                auxPedidoDet.InventarioId = item.ItemInventario.Id;
                item.Calcular();
                auxPedidoDet.Subtotal += item.SubTotal;
                auxPedido.PedidoDet.Add(auxPedidoDet);
            }

            PedidosRepo.Agregar(auxPedido);
        }
    }
}