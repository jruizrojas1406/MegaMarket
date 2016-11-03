using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class CargoBC
    {
        /// <summary>
        /// Listar Cargos
        /// </summary>
        /// <returns></returns>        
        public List<Cargo> ListarCargo()
        {
            return new CargoDALC().ListarCargo().ToList();
        }
    }
}
