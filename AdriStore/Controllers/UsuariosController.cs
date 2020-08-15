using ADRISTORE.BE;
using ADRISTORE.Entities;
using AdriStoreWeb.BE;
using AdriStoreWeb.BLL;
using AdriStoreWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;



namespace AdriStoreWeb.Controllers
{
    public class UsuariosController : MasterController
    {
      
        public String SetVisibilityAdminMenu()
        {

            if (!IsAdminUserLoggedIn())
                return "style='visibility:hidden'";
            else
                return "style='visibility:visible'";

        }

        public ActionResult Login() {
            return View("Login");
        }

        public ActionResult LogOff() {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public ActionResult GoToAccesoDenegado() {
            return View("AccesoDenegado");
        }

        [HttpPost]
        public ActionResult DoLogin([FromBody]Usuario unUsuario) {
            var Repo = new UsuarioBLL();

            if (Repo.isLoginOK(unUsuario))
            {
                var auxUsuario = Repo.ObtenerXNombre(unUsuario.Nombre);
                HttpContext.Session.SetString("UsuarioLogueado",JsonConvert.SerializeObject(auxUsuario));
                HttpContext.Session.SetString("UsuarioLogueadoNombre", auxUsuario.Nombre);
                
            }
            else
                return RedirectToAction("GoToAccesoDenegado");

            return Json(new { action = "Redirect", url = Url.Action("Index", "Listado") });

        }

        // GET: Usuarios
        public ActionResult Index()
        {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var auxLista = new UsuarioBLL().Listar();
            //ViewBag.Usuarios = auxLista;
            ViewBag.Controlador = "Usuarios";
            return View("Usuarios",auxLista);
        }

        public ActionResult PrepararAgregar() {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.Controlador = "Usuarios";
            var auxObj = new Usuario();
            return View("UsuarioItem",auxObj);
        }

        public ActionResult PrepararModificar(long ID) {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.Controlador = "Usuarios";
            var auxObj = new UsuarioBLL().ObtenerXID(ID);
            return View("UsuarioItem", auxObj);
        }

        [HttpPost]
        public ActionResult Agregar(Usuario entidad) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new UsuarioBLL();
            Repo.Agregar(entidad);
            return View("Usuarios");
        }

        [HttpPost]
        public ActionResult Modificar(Usuario entidad)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new UsuarioBLL();
            Repo.Modificar(entidad);
            return View("Usuarios");
        }

        [HttpPost]
        public ActionResult Eliminar(Usuario entidad) {
            if (!ModelState.IsValid)
            {
                return View("Error", new Error() { Message = "Error in data" });
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new UsuarioBLL();
            Repo.Eliminar(entidad);
            return View("Usuarios");
        }
    }
}