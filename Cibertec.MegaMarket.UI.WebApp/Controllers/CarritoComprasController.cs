﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.MegaMarket.UI.WebApp.Controllers
{
    public class CarritoComprasController : Controller
    {
        // GET: CarritoCompras
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarritoCompras/AdicionarAlCarrito/5
        public ActionResult AdicionarAlCarrito(int id)
        {
            return View();
        }
    }
}
