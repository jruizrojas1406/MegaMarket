using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.DL.DALC
{
    public class CategoriaDALC
    {
        public IQueryable<Categoria> ListarCategorias(string NombreCategoria)
        {
            var bd = new MegaMarketEntities();
            return bd.Categorias
                .Where(s => s.Nombre.Contains(NombreCategoria));
        }

        public void InsertarCategoria(Categoria categoria)
        {
            using (var db = new MegaMarketEntities())
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
            }
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            using (var bd = new MegaMarketEntities())
            {
                var cate = bd.Categorias.SingleOrDefault(x => x.IdCategoria == categoria.IdCategoria);

                // Actualizamos el registro
                cate.Nombre = categoria.Nombre;
                cate.Descripcion = categoria.Descripcion;
                bd.SaveChanges();
            }
        }

        public void EliminarCategoria(int CodCategoria)
        {
            using (var db = new MegaMarketEntities())
            {
                var categoria = db.Categorias.SingleOrDefault(x => x.IdCategoria == CodCategoria);
                db.Categorias.Remove(categoria);
                db.SaveChanges();
            }
        }
    }
}
