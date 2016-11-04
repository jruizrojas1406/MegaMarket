using Cibertec.MegaMarket.UI.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.MegaMarket.UI.WebApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        [NoLogin]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // GET: /logOff/
        public ActionResult LogOff()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Account/Login");
        }
    }
}