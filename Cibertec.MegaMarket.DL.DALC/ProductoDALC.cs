﻿using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cibertec.MegaMarket.DL.DALC
{
    public class ProductoDALC
    {
        public IQueryable<Producto> ListarProductos(string NombreProducto)
        {
            var bd = new MegaMarketEntities();
            return bd.Productoes
                .Include(a => a.Categoria)
                .Include(b => b.UnidMedida)
                .Where(s => s.Nombre.Contains(NombreProducto));
        }

        public IQueryable<Producto> ListarProductosxCategoria(int idCategoria)
        {
            var bd = new MegaMarketEntities();
            return bd.Productoes
                .Include(a => a.Categoria)
                .Include(b => b.UnidMedida)
                .Where(s => s.IdCategoria == idCategoria);
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            var bd = new MegaMarketEntities();
            return bd.Productoes
                .Where(x => x.IdProducto == idProducto)
                .FirstOrDefault();                  
        }

        public void InsertarProducto(Producto producto)
        {
            using (var db = new MegaMarketEntities())
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (var bd = new MegaMarketEntities())
            {
                var prod = bd.Productoes.SingleOrDefault(x => x.IdProducto == producto.IdProducto);

                // Actualizamos el registro
                prod.Nombre = producto.Nombre;
                prod.Descripcion = producto.Descripcion;
                prod.IdCategoria = producto.IdCategoria;
                prod.IdUnidMedida = producto.IdUnidMedida;
                prod.IdMarca = producto.IdMarca;
                prod.Stock = producto.Stock;
                prod.Precio = producto.Precio;
                bd.SaveChanges();
            }
        }

        public void EliminarProducto(int CodProducto)
        {
            using (var db = new MegaMarketEntities())
            {
                var producto = db.Productoes.SingleOrDefault(x => x.IdProducto == CodProducto);
                db.Productoes.Remove(producto);
                db.SaveChanges();
            }
        }
    }
}
