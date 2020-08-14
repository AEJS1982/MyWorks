using AdriStoreWeb.BLL;
using AdriStoreWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AdriStoreWeb.Controllers
{
    public class ListadoController : MasterController
    {
        // GET: Listado
        public ActionResult Index()
        {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");


            var InventarioRepo = new InventarioBLL();
            ViewBag.Lista=InventarioRepo.Listar();
            HttpContext.Session.SetString("Test","1234");
            return View("Listado");
        }
    }
}