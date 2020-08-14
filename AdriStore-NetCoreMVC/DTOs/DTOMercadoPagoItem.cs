using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdriStoreWeb.BE.DTOs
{
    public class DTOMercadoPagoItem
    {
        public String title { get; set; }
        public String quantity { get; set; }
        public String currency_id { get; set; }
        public String unit_price { get; set; }
    }
}
