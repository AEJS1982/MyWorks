using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AdriStoreWeb.Controllers
{
    public class InicioController : MasterController
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View("MainPage");
        }
    }
}