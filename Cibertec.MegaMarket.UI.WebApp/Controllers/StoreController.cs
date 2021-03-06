﻿using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.MegaMarket.UI.WebApp.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        // GET: Store/CategoriaMenu
        [ChildActionOnly]
        public ActionResult CategoriaMenu()
        {
            List<Categoria> categoria = new List<Categoria>();
            categoria = new CategoriaBC().ListarCategorias(string.Empty);
            return PartialView(categoria);
        }

        //
        // GET: /Store/ProductoCategoria/1
        public ActionResult ProductoCategoria(int idCategoria)
        {
            List<Producto> producto = new List<Producto>();
            producto = new ProductoBC().ListarProductosxCategoria(idCategoria);
            return View(producto);
        }

        //
        // GET: /User/ImagenProducto/<byte>
        public ActionResult ImagenProducto(int IdProducto)
        {           
            Producto producto = new Producto();
            producto = new ProductoBC().ObtenerProductoPorId(IdProducto);
            if (producto.Foto == null || producto.Foto.GetType() == typeof(DBNull))
                return File("~/Content/images/NotFound.png", "image/png");
            return File(producto.Foto, "image/jpeg");
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
