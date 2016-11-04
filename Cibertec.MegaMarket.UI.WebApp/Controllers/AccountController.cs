using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.UI.WebApp.Helpers;
using Cibertec.MegaMarket.UI.WebApp.Models;
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
        // GET: /Account/Login/<OBJECT>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection FrmUsuario)
        {
            Usuario usuario = new Usuario();
            Retorno retorno = new Retorno();
            retorno.Estado = 0;
            usuario.Login = FrmUsuario["Login"];
            usuario.Password = new Encriptacion().EncodePassword(FrmUsuario["Password"]);
            var DatosUsuario = new UsuarioBC().AutentificarUsuario(usuario);
            if (DatosUsuario != null)
            {
                retorno.Estado = 1;
                retorno.Url = Url.Content("~/Home");
                string[] data =
                {
                    DatosUsuario.IdUsuario.ToString(),
                    DatosUsuario.Empleado.Nombres +" "+ DatosUsuario.Empleado.Apellidos,
                    string.Empty
                };
                SessionHelper.AddUserToSession(DatosUsuario.Login, true, string.Join("|", data));
            }
            else
            {
                retorno.Mensaje = "Ud. no cuenta con los permisos requeridos para ingresar al sistema";
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
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