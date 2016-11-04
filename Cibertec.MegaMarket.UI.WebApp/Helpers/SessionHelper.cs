using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Cibertec.MegaMarket.UI.WebApp.Helpers
{
    public class SessionHelper
    {
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// obtine el Nombre de Usuario Logueado
        /// </summary>
        /// <returns></returns>
        public static int GetUserID()
        {
            int UserID = 0;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    UserID = Convert.ToInt32(ticket.UserData.Split('|')[0]);
                }
            }
            return UserID;
        }

        public static string GetIdppiCodigo()
        {
            string IdppiCodigo = "";
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    IdppiCodigo = (string)ticket.UserData.Split('|')[1];
                }
            }
            return IdppiCodigo;
        }

        /// <summary>
        /// Almacena datos del Usuario  Logueado
        /// </summary>
        /// <param name="UserName">string</param>
        /// <param name="UsuarioNombres">string</param>
        public static void AddUserToSession(string UserID, string UsuarioNombres)
        {
            HttpCookie cookie = FormsAuthentication.GetAuthCookie("userAccount", false);
            FormsAuthenticationTicket ft = FormsAuthentication.Decrypt(cookie.Value);
            FormsAuthenticationTicket newFt =
                new FormsAuthenticationTicket(
                    ft.Version,
                    UsuarioNombres,
                    ft.IssueDate,
                    ft.Expiration,
                    ft.IsPersistent,
                    UserID);

            string encryptedValue = FormsAuthentication.Encrypt(newFt);
            cookie.Value = encryptedValue;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}