using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class MarcaBC
    {
        public List<Marca> ListarMarca()
        {
            return new MarcaDALC().ListarMarca().ToList();
        }
    }
}
