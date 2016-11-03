using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class UbigeoBC
    {
        public List<Pai> ListarPaises()
        {
            return new UbigeoDALC().ListarPaises().ToList();
        }

        public List<Ciudad> ListarCiudad(int CodPais)
        {
            return new UbigeoDALC().ListarCiudad(CodPais).ToList();
        }

        public List<Distrito> ListarDistrito(int CodPais, int CodCiudad)
        {
            return new UbigeoDALC().ListarDistrito(CodPais, CodCiudad).ToList();
        }
    }
}
