using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.MegaMarket.UI.WebApp.Models
{
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Anderson Ruiz (17/08/2016)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    /// <summary> Entidad = Retorno </summary>
    /// <returns>
    /// ESTADO
    /// 0 :==> WARNING
    /// 1 :==> OK
    /// 2 :==> ERROR
    /// <returns>
    public class Retorno
    {
        public object RetVal { get; set; }
        public Nullable<int> Estado { get; set; }
        public string Mensaje { get; set; }
        public string Url { get; set; }
    }
}
