using ADRISTORE.BE;
using AdriStoreWeb.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
//using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AdriStoreWeb
{
    public static class Helper
    {
        public static IMemoryCache cache;
        public static IHttpContextAccessor accessor;

        public static List<RubroCatalogo> GetListaRubros() {

            
            /*if (cache.Get("ListaRubros") == null)
                cache.Set("ListaRubros",new RubroCatalogoBLL().Listar());

            return (List<RubroCatalogo>)cache.Get("ListaRubros");*/
            return new RubroCatalogoBLL().Listar();


        }

        public static List<Cliente> GetListaClientes() {
            /*if (cache.Get("ListaClientes") == null)
                cache.Set("ListaClientes",new UsuarioBLL().Listar());

            return (List<Cliente>)cache.Get("ListaClientes");*/

            return new ClienteBLL().Listar();
        }

        public static List<Catalogo> GetCatalogo() {
            /*if (cache.Get("ListaCatalogo") == null)
                cache.Set("ListaCatalogo",new CatalogoBLL().Listar());

            return (List<Catalogo>)cache.Get("ListaCatalogo");*/

            return new CatalogoBLL().Listar();
        }

        public static String GetUsuarioLogueado() {

            return accessor.HttpContext.Session.GetString("UsuarioLogueadoNombre");
        }







    }
}