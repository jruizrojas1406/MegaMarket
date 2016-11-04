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

        public static string GetFullNameUser()
        {
            string FullNameUser = string.Empty;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    FullNameUser = (string)ticket.UserData.Split('|')[1];
                }
            }
            return FullNameUser;
        }

        /// <summary>
        /// Almacena datos del Usuario  Logueado
        /// </summary>
        public static void AddUserToSession(string UserName, bool Estado, string Data)
        {
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(UserName, Estado);
            FormsAuthenticationTicket ft = FormsAuthentication.Decrypt(cookie.Value);
            FormsAuthenticationTicket newFt =
                new FormsAuthenticationTicket(
                    ft.Version,
                    UserName,
                    ft.IssueDate,
                    ft.Expiration,
                    ft.IsPersistent,
                    Data);

            string encryptedValue = FormsAuthentication.Encrypt(newFt);
            cookie.Value = encryptedValue;
            HttpContext.Current.Response.Cookies.Add(cookie);

        }
    }
}