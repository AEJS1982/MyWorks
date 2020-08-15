using ADRISTORE.BE;
using ADRISTORE.Entities;
using AdriStoreWeb.BE;
using AdriStoreWeb.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AdriStoreWeb.Controllers
{
    public class PedidosController : MasterController
    {
        private PedidosBLL _Repo;

        public PedidosBLL Repo
        {
            get
            {
                if (_Repo == null)
                    _Repo = new PedidosBLL();

                return _Repo;
            }

            set
            {
                _Repo = value;
            }
        }

        public ActionResult Index() {
            return View("Pedidos",Repo.Listar());
        }

        [HttpGet]
        public ActionResult Buscar()
        {
            var estadoPedido = "T";
            var fechaInicial= DateTime.Now.AddDays(-15);
            var fechaFinal = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.Query["estado"].FirstOrDefault()))
                estadoPedido = Request.Query["estado"].First().ToString().Substring(0, 1);
            
            if (!String.IsNullOrEmpty(Request.Query["fechaInicial"].FirstOrDefault()))
                fechaInicial = DateTime.Parse(Request.Query["fechaInicial"].First().ToString());

            if (!String.IsNullOrEmpty(Request.Query["fechaFinal"].FirstOrDefault()))
                fechaFinal =DateTime.Parse(Request.Query["fechaFinal"].First().ToString());

            return View("Pedidos", Repo.Buscar(estadoPedido,fechaInicial,fechaFinal));
        }

        [HttpPost]
        public ActionResult AgregarItem([FromBody]PedidoCab unPedido) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            Repo.Agregar(unPedido);
            return View("Pedidos");
        }

        [HttpGet]
        public ActionResult EliminarItem(long ID)
        {
            var auxObj = Repo.ObtenerXID(ID);
            Repo.Eliminar(auxObj);
            return View("Pedidos");
        }

        [HttpGet]
        public ActionResult MarcarComoEntregado(long ID) {
            var auxObj = Repo.ObtenerXID(ID);
            auxObj.Estado = "E";
            Repo.Modificar(auxObj);
            return View("Pedidos");
        }

        [HttpGet]
        public ActionResult MarcarComoCancelado(long ID)
        {
            var auxObj = Repo.ObtenerXID(ID);
            auxObj.Estado = "C";
            Repo.Modificar(auxObj);
            return View("Pedidos");
        }

    }
}