using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class CategoriaBC
    {
        public List<Categoria> ListarCategorias(string NombreCategoria)
        {
            return new CategoriaDALC().ListarCategorias(NombreCategoria).ToList();
        }

        public void InsertarCategoria(Categoria categoria)
        {
            new CategoriaDALC().InsertarCategoria(categoria);
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            new CategoriaDALC().ActualizarCategoria(categoria);
        }

        public void EliminarCategoria(int CodCategoria)
        {
            new CategoriaDALC().EliminarCategoria(CodCategoria);
        }
    }
}
