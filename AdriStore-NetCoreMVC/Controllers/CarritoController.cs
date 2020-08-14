using AdriStoreWeb.BLL;
using AdriStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ADRISTORE.DTOs;
using System.Text;
using ADRISTORE.Entities;

namespace AdriStoreWeb.Controllers
{
    public class CarritoController : MasterController
    {
        private CatalogoBLL RepoCatalogo = new CatalogoBLL();
        private SessionCarrito _Carrito;

        public SessionCarrito Carrito
        {
            get {
                if (_Carrito == null)
                    _Carrito = new SessionCarrito();

                return _Carrito;
            }
            set {
                _Carrito = value;
            }
        }

        // GET: Carrito
        public ActionResult Index()
        {
            return View("Carrito", Carrito.getCarrito());
        }

        [HttpGet]
        public ActionResult PrepararAgregarItem(long ID) {
            //Recuperar item del Inventario, mostrar la página de agregar al carrito
            //con los campos autocompletados
            var InventarioRepo = new InventarioBLL();
            var newItem = new DTOCarritoItem();
            newItem.InventarioID = ID;
            newItem.ItemInventario = InventarioRepo.ObtenerXID(ID);
            newItem.SessionID = HttpContext.Session.Id;
            //newItem.Calcular();
            ViewBag.ModoOper = "NEW";
            return View("CarritoItem", newItem);
        }

        [HttpPost]
        public ActionResult PrepararModificarItem([FromBody]CarritoCompraItem itemExistente) {
            var unItem = Carrito.getCarrito().Items.Where(x => x.ItemInventario.Id == itemExistente.ItemInventario.Id).FirstOrDefault();
            unItem.SessionID = HttpContext.Session.Id;
            ViewBag.ModoOper = "EDIT";
            return View("CarritoItem", unItem);

        }

        [HttpPost]
        public ActionResult GuardarAlta([FromBody]DTOCarritoItem nuevoItem) {

            if (!ModelState.IsValid)
            {
                return View("Error", new Error() {Message="Error in data" });
            }

            if (nuevoItem.ItemInventario != null)
            {
                if (nuevoItem.ItemInventario.Catalogo == null)
                { 
                    var auxCatalogoItem=RepoCatalogo.ObtenerXID(nuevoItem.ItemInventario.CatalogoId.Value);
                    nuevoItem.ItemInventario.Catalogo = auxCatalogoItem;
                }

                nuevoItem.Calcular();
                var Inv =new InventarioBLL();
                //nuevoItem.ItemInventario=Inv.ObtenerXID(nuevoItem.ItemInventario.Catalogo.Id);
                saveItemInCarrito(nuevoItem);
                return View("Carrito",Carrito.getCarrito());
            }

            return View("Carrito", Carrito.getCarrito());
            
        }

        public DTOCarritoCompra getCarrito() {
            return Carrito.getCarrito();          
        }

        public void saveCarrito(DTOCarritoCompra auxCarrito) {
            auxCarrito.SessionID = HttpContext.Session.Id;
            Carrito.setCarrito(auxCarrito);
        }

        private void saveItemInCarrito(DTOCarritoItem nuevoItem)
        {
            var auxCarrito = Carrito.getCarrito();
            auxCarrito.Agregar(nuevoItem);
            Carrito.setCarrito(auxCarrito);
        }

        public void quitarIteminCarrito(DTOCarritoItem nuevoItem) {
            var auxCarrito = Carrito.getCarrito();
            auxCarrito.Remover(nuevoItem.ID);
            this.saveCarrito(auxCarrito);
        }

        [HttpPost]
        public ActionResult ModificarItem([FromBody]DTOCarritoItem itemExistente) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            var auxCarrito = Carrito.getCarrito();
            var oldItem = auxCarrito.Items.Where(x => x.InventarioID == itemExistente.InventarioID).FirstOrDefault();
            auxCarrito.Modificar(oldItem.ID, itemExistente);
            Carrito.setCarrito(auxCarrito);
            return View("Carrito", auxCarrito);
        }

        [HttpGet]
        public ActionResult QuitarItem(int ID)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            var auxCarrito = Carrito.getCarrito();
            auxCarrito.Remover(ID);
            Carrito.setCarrito(auxCarrito);
            return View("Carrito", auxCarrito);
        }

        public ActionResult BeginCheckout() {
            //var auxCarrito = Carrito.ObtenerCompra();
            //generar pedido a partir del checkout y dejarlo ahí

            Carrito.GenerarPedido();
            return View("Checkout", Carrito.getCarrito());
        }
    }
}