using Cibertec.MegaMarket.BL.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.MegaMarket.DL.DALC;

namespace Cibertec.MegaMarket.BL.BC
{
   public class UnidadMedidaBC
    {
        public List<UnidMedida> ListarUnidadMedida()
        {
           return new UnidadMedidaDALC().ListarUnidadMedida().ToList();
        }
    }
}
