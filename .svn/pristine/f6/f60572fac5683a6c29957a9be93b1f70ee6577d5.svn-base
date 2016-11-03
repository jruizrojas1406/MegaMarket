using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class ProductoBC
    {
        public List<Producto> ListarProductos(string NombreProducto)
        {
            return new ProductoDALC().ListarProductos(NombreProducto).ToList();
        }

        public void InsertarProducto(Producto producto)
        {
            new ProductoDALC().InsertarProducto(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            new ProductoDALC().ActualizarProducto(producto);
        }

        public void EliminarProducto(int CodProducto)
        {
            new ProductoDALC().EliminarProducto(CodProducto);
        }
    }
}
