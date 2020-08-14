using ADRISTORE.BE;
using AdriStoreWeb.BE;
using AdriStoreWeb.BE.DTOs;
using AdriStoreWeb.BLL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AdriStoreWeb.Controllers
{
    public class CatalogoController : MasterController
    {
        private String _env;

        public CatalogoController(IHostingEnvironment env) {
            _env = env.WebRootPath;
        }

        // GET: Catalogo
        public ActionResult Index()
        {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var ListaCatalogo = new CatalogoBLL().Listar();
            return View("Catalogo",ListaCatalogo);
        }

        public String getList() {
            StringBuilder SB = new StringBuilder();
            if (this.IsAdminUserLoggedIn() == false)
                throw new Exception("Access Denied");

            var Repo = new CatalogoBLL();
            var QryListado = from auxObj in Repo.Listar()
                             select new
                             {
                                 auxObj.Nombre,
                                 auxObj.Habilitado,
                                 auxObj.Precio
                             };

            var Ldo = QryListado.ToList();

            SB.Append("{ \"data\": [");

            for (int i = 0; i <= Ldo.Count()-1; i++)
            {
                var item = Ldo[i];
                SB.Append("[\"" + item.Nombre + "\",\"" + item.Precio + "\",\"" + item.Habilitado + "\"]");

                if (i < Ldo.Count()-1)
                    SB.Append(",");
            }

            SB.Append("]}");

            return SB.ToString();
        }

        public ActionResult PrepararAgregarItem() {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.ModoOper = "NEW";
            ViewBag.AccionOper = "AgregarItem";
            var auxObj = new Catalogo();
            return View("CatalogoItem",auxObj);
        }

        public ActionResult PrepararModificarItem(long ID) {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            ViewBag.ModoOper = "EDIT";
            var Repo = new CatalogoBLL();
            var auxObj=Repo.ObtenerXID(ID);
            return View("CatalogoItem", auxObj);
        }

        //POST:Agregar
        [HttpPost]
        public ActionResult AgregarItem([FromBody]DTOCatalogoItem auxDTO) {

            if (!ModelState.IsValid)
            {
                return View("Error", "Error en datos!");
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Rnd = new Random();
            var Repo = new CatalogoBLL();
            //auxDTO.Item.Rubro=Helper.GetListaRubros().First(x => x.Id == auxDTO.Item.RubroId);

            if (auxDTO.Foto != null)
            {
                var NombreArch = auxDTO.Foto.PathFoto;

                //String PathGuardar = Path.Combine(_env, "~/Fotos/") + NombreArch;
                //auxDTO.Foto.PathFoto = PathGuardar;
                auxDTO.Foto.PathFoto =NombreArch;
                auxDTO.Item.Foto = auxDTO.Foto.PathFoto;
            }

            Repo.Agregar(auxDTO);
            
            return View("Catalogo");
        }

        //POST:Modificar
        [HttpPost]
        public ActionResult ModificarItem([FromBody]DTOCatalogoItem auxDTO) {

            if (!ModelState.IsValid)
            {
                return View("Error", "Error en datos!");
            }

            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new CatalogoBLL();

            Repo.Modificar(auxDTO);

            //TODO:Reemplazar la foto existente en el servidor
      

            return View("Catalogo");
        }

        //POST:Eliminar
        [HttpGet]
        public ActionResult EliminarItem(long ID) {
            if (this.IsAdminUserLoggedIn() == false)
                return View("AccesoDenegado");

            var Repo = new CatalogoBLL();
            var auxObj = Repo.ObtenerXID(ID);
            Repo.Eliminar(auxObj);
            return View("Catalogo");
        }
    }
}