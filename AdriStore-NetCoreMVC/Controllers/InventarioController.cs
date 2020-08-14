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

    public class InventarioController : MasterController
    {
        private InventarioBLL Repo=new InventarioBLL();

        // GET: Inventario
        public ActionResult Index()
        {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var ListaInventario = new InventarioBLL().Listar();
            return View("Inventario", ListaInventario);
        }

        public ActionResult PrepararAgregarItem() {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.ModoOper = "NEW";

            var auxObj = new Inventario();
            return View("InventarioItem", auxObj);
        }


        public ActionResult PrepararModificarItem(long ID) {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.ModoOper = "EDIT";

            var auxObj = new InventarioBLL().ObtenerXID(ID);

            return View("InventarioItem", auxObj);
        }

        [HttpPost]
        public ActionResult AgregarItem([FromBody]Inventario entidad) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new InventarioBLL();
            Repo.Agregar(entidad);
            ViewBag.Inventario = Repo.Listar();

            return View("Inventario");
        }

        [HttpPost]
        public ActionResult ModificarItem([FromBody]Inventario entidad) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new InventarioBLL();
            Repo.Modificar(entidad);
            ViewBag.Inventario = Repo.Listar();

            return View("Inventario"); 
        }

        [HttpGet]
        public ActionResult EliminarItem(long ID) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new InventarioBLL();

            Repo.Eliminar(ID);
            return View("Inventario");
        }

    }
}