using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Cibertec.MegaMarket.UI.WebApp.Helpers
{
    public class AppSettings
    {
        public static string AppName
        {
            get { return ConfigurationManager.AppSettings["AppName"].ToString(); }
        }

    }
}