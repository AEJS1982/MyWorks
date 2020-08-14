using AdriStoreWeb.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADRISTORE.DTOs
{
    [Serializable]
    public class DTOCarritoCompra
    {
        private List<DTOCarritoItem> items;
        private decimal _SubTotal;
        private String _SessionID;

        public DTOCarritoCompra() {
            items = new List<DTOCarritoItem>();
        }

        public List<DTOCarritoItem> Items { get => items; set => items = value; }
        public decimal SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public string SessionID { get => _SessionID; set => _SessionID = value; }

        public decimal CalcularTotal()
        {
            this.SubTotal=this.items.Sum(x => x.ItemInventario.Catalogo.Precio * x.Cantidad);
            return this.SubTotal;
        }

        public void Agregar(DTOCarritoItem item)
        {
            item.ID = this.Items.Count + 1;
            this.Items.Add(item);
        }

        public void Remover(int ID) {
            var auxObj = this.Items.Where(x => x.ID == ID).FirstOrDefault();
            this.Items.Remove(auxObj);
        }

        public void Modificar(int ID, DTOCarritoItem itemExistente)
        {
            var auxObj = this.Items.Where(x => x.ID == ID).FirstOrDefault();
            auxObj.Cantidad = itemExistente.Cantidad;
            auxObj.InventarioID = itemExistente.InventarioID;
            auxObj.Precio = itemExistente.Precio;
        }

        public List<DTOCarritoItem> ListarItems()
        {
            var CatalogoRepo = new CatalogoBLL();

            foreach (var item in this.Items)
            {
                if (item.ItemInventario != null)
                    if (item.ItemInventario.Catalogo != null)
                        item.ItemInventario.Catalogo = CatalogoRepo.ObtenerXID(item.ItemInventario.Catalogo.Id);
            }

            return this.Items;
        }
    }
}
