using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.DL.DALC
{
    public class UbigeoDALC
    {
        public IQueryable<Pai> ListarPaises()
        {
            var db = new MegaMarketEntities();
            return db.Pais;
        }

        public IQueryable<Ciudad> ListarCiudad(int CodPais)
        {
            var db = new MegaMarketEntities();
            return db.Ciudads.Where(x=>x.IdPais==CodPais);
        }

        public IQueryable<Distrito> ListarDistrito(int CodPais,int CodCiudad)
        {
            var db = new MegaMarketEntities();
            return db.Distritoes.Where(x => x.IdPais == CodPais && x.IdCiudad == CodCiudad);
        }
    }
}
