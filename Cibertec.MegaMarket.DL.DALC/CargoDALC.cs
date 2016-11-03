﻿using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.DL.DALC
{
    public class CargoDALC
    {
        public IQueryable<Cargo> ListarCargo()
        {
            var bd = new MegaMarketEntities();
            return bd.Cargoes;
        }
    }
}
