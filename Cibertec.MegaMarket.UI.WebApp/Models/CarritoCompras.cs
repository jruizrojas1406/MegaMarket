using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.MegaMarket.UI.WebApp.Models
{
    public class CarritoCompras
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}