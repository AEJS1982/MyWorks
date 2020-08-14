using AdriStoreWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdriStoreWeb.BE;
using Microsoft.AspNetCore.Mvc;
using ADRISTORE.BE;
using ADRISTORE.Entities;

namespace AdriStoreWeb.Controllers
{
    public class RubrosController : MasterController
    {
        // GET: Rubros
        public ActionResult Index()
        {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var ListaRubros = new RubroCatalogoBLL().Listar().AsEnumerable<RubroCatalogo>();
            return View("Rubros",ListaRubros);
        }

        public ActionResult Get() {
            return View("Rubros");
        }

        public JsonResult getList() {

            /*if (this.IsAdminUserLoggedIn() == false)
                return null;*/

            var ListadoRubros = new RubroCatalogoBLL().Listar();
            var QryListaRubros = from auxObj in ListadoRubros
                    select new {
                        auxObj.Nombre,
                        Habilitado="<input type='checkbox' checked='" + auxObj.Habilitado + "'/>",
                        auxObj.Comentario,
                        LinkEditar ="<a href='#' onclick='Modificar(" + auxObj.Id + ")'>Editar</a>",
                        LinkEliminar= "<a href='#' onclick='Eliminar(" + auxObj.Id + ")'>Eliminar</a>" };
            

            return Json(QryListaRubros.ToList());
        }

        public ActionResult PrepararAgregarItem()
        {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.ModoOper = "NEW";
            RubroCatalogo auxObj = new RubroCatalogo();
            return View("RubroItem",auxObj);
        }

        public ActionResult PrepararModificarItem(long ID) {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.ModoOper = "EDIT";
            var auxObj = new RubroCatalogoBLL().ObtenerXID(ID);
            return View("RubroItem", auxObj);
        }

        [HttpPost]
        public ActionResult AgregarItem([FromBody] RubroCatalogo entidad)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new RubroCatalogoBLL();
            Repo.Agregar(entidad);
            ViewBag.Rubros = Repo.Listar();
            return View("Rubros");
        }

        [HttpPost]
        public ActionResult ModificarItem([FromBody] RubroCatalogo entidad)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new RubroCatalogoBLL();
            Repo.Modificar(entidad);
            ViewBag.Rubros = Repo.Listar();
            return View("Rubros");

        }
        
        [HttpGet]
        public ActionResult EliminarItem(int ID)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new RubroCatalogoBLL();
            var auxObj = new RubroCatalogo();
            auxObj.Id = ID;
            Repo.Eliminar(auxObj);
            ViewBag.Rubros = Repo.Listar();
            return View("Rubros");
        }
    }
}