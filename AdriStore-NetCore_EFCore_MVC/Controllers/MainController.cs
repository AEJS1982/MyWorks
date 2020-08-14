using AdriStoreWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdriStoreWeb.Controllers
{
    public class MainController : Controller
    {

        // GET: Main
        public ActionResult Index()
        {
            return View("Main");
        }
    }
}