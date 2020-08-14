using System;
using System.Linq;
using AdriStoreWeb.BE;
using AdriStoreWeb.BLL;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AdriStoreWeb.Models;
using ADRISTORE.BE;
using Newtonsoft.Json.Linq;

namespace AdriStoreWeb.Controllers
{
    public class MasterController : Controller
    {
        public MasterController() {
            
        }


        public ActionResult DoLogon(String Usuario, String Password)
        {
            var UsuariosRepo = new UsuarioBLL();
            var UserList = UsuariosRepo.Listar();
            var auxUser = UserList.Where(x => x.Nombre.ToUpper().Trim() == Usuario.ToUpper().Trim()).FirstOrDefault();

            if (auxUser != null)
            {
                if (auxUser.Password.Equals(Password))
                {
                    HttpContext.Session.SetString("UsuarioLogueado",JsonConvert.SerializeObject(auxUser));
                    return View("Main");
                }
                else
                    return View("Login");
            }
            else
            {
                return View("Login");
            }
        }

        public Boolean IsUserLogged()
        {
            string strUsuario = HttpContext.Session.GetString("UsuarioLogueado");
            var auxUsuario = (JObject)JsonConvert.DeserializeObject(strUsuario);

            if (auxUsuario!=null)
                ViewBag.Usuario = auxUsuario;
            
            return (auxUsuario != null);
        }

        public bool IsAdminUserLoggedIn()
        {
            /*if (Debugger.IsAttached == true)
                return true;*/

            string strUsuario = HttpContext.Session.GetString("UsuarioLogueado");
            if (strUsuario == null)
                return false;

            var auxUsuario =(JObject) JsonConvert.DeserializeObject(strUsuario);

            if (auxUsuario == null)
                return false;
            else
            {

                ViewBag.Usuario = auxUsuario;
                return true;
            }

        }
    }
}