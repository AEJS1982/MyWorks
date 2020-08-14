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
    public class ClientesController : MasterController
    {
        private ClienteBLL _Repo;

        protected ClienteBLL Repo {
            get {
                if (_Repo == null)
                    _Repo = new ClienteBLL();

                return _Repo; }
            set { _Repo = value; }
        }

        // GET: Clientes
        public ActionResult Listar()
        {
            var auxLista = Repo.Listar();
            ViewBag.EsAdmin = false;
            ViewBag.Controlador = "Clientes";
            return View("Clientes",auxLista);
        }

        public ActionResult PrepararAlta() {
            ViewBag.ModoOper = "NEW";
            ViewBag.EsAdmin = false;
            ViewBag.Controlador = "Clientes";
            var auxCliente = new Usuario();
            return View("~/Views/Clientes/ClienteItem.cshtml", auxCliente);

        }

        public ActionResult PrepararModificar(long ID)
        {
            ViewBag.ModoOper = "EDIT";
            ViewBag.EsAdmin = false;
            ViewBag.Controlador = "Clientes";
            var auxCliente = Repo.ObtenerXID(ID);
            return View("~/Views/Cliente/UsuarioItem.cshtml", auxCliente);

        }

        [HttpPost]
        public ActionResult Agregar([FromBody]Cliente unCliente) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            Repo.Agregar(unCliente);
            var auxLista = Repo.Listar();
            ViewBag.Usuarios = auxLista;
            return View("Cliente",auxLista);
        }

        [HttpPost]
        public ActionResult Modificar([FromBody]Cliente unCliente) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            Repo.Modificar(unCliente);
            var auxLista = Repo.Listar();
            return View("Usuarios",auxLista);
        }

        [HttpPost]
        public ActionResult Eliminar([FromBody]Cliente unCliente) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            Repo.Eliminar(unCliente);
            var auxLista = Repo.Listar();
            return View("Usuarios",auxLista);
        }

    }
}