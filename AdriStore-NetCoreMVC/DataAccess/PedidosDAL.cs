using ADRISTORE.BE;
using AdriStoreWeb.BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.DAL
{
    public class PedidosDAL : DBContext, ICRUD<PedidoCab>
    {
        private String _NombreTablaDET;

        public PedidosDAL() {
            /*this.NombreTabla = "PedidoCAB";
            this.NombreTablaDET = "PedidoDET";*/
        }

        public string NombreTablaDET
        {
            get
            {
                return _NombreTablaDET;
            }

            set
            {
                _NombreTablaDET = value;
            }
        }

        public void Agregar(PedidoCab entidad)
        {
            long auxID = 1;
            entidad.Id = 1;

            if (this.PedidoCab.Count()>0)
                entidad.Id=this.PedidoCab.Max(x => x.Id) + 1;

            entidad.FechaAlta = DateTime.Now;
            entidad.FechaEntrega = DateTime.Now.AddDays(15);

            foreach (var item in entidad.PedidoDet)
            {
                if (this.PedidoDet.Count()>0)
                     auxID = this.PedidoDet.Max(x => x.Id);

                item.Id =auxID + 1;
            }

            this.PedidoCab.Add(entidad);
            this.SaveChanges();
        }

        public void Eliminar(PedidoCab entidad)
        {
            var auxObj = this.PedidoCab.FirstOrDefault(x => x.Id==entidad.Id);
            if (auxObj != null)
            {
                this.PedidoCab.Remove(auxObj);
                this.SaveChanges();
            }
        }

        public List<PedidoCab> Listar()
        {
            return this.PedidoCab.Include("cliente").ToList();
        }

        public List<PedidoCab> Buscar(string estadoPedido, DateTime fechaInicial, DateTime fechaFinal)
        {
            var Qry = from auxCab in this.PedidoCab
                      join auxDet in this.PedidoDet  on auxCab.Id equals auxDet.PedidoCabId
                      where (auxCab.Estado == estadoPedido && auxCab.FechaAlta >= fechaInicial 
                      && auxCab.FechaAlta <= fechaFinal)
                      orderby auxCab.FechaAlta ascending
                      select auxCab;

            if (estadoPedido != "T")
            {
                Qry.Where(x => x.Estado == estadoPedido);
                return Qry.Include("cliente").ToList();
            }
            else
                return Qry.Include("cliente").ToList();
        }

        public void Modificar(PedidoCab entidad)
        {
            var auxObj = this.PedidoCab.FirstOrDefault(x => x.Id==entidad.Id);

            if (auxObj != null)
            {
                this.Entry(auxObj).CurrentValues.SetValues(this.Entry(entidad).CurrentValues);
                this.SaveChanges();
            }
        }

        public PedidoCab ObtenerXID(long ID)
        {
            return this.PedidoCab.Include("PedidoDet").FirstOrDefault(x => x.Id == ID);
        }
    }
}
