using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cibertec.MegaMarket.DL.DALC
{
    public class UsuarioDALC
    {
        public Usuario AutentificarUsuario(Usuario usuario)
        {
            var bd = new MegaMarketEntities();

            Usuario user = bd.Usuarios
                .Include(x => x.Empleado)
                .FirstOrDefault(x => x.Login == usuario.Login && x.Password == usuario.Password);
            return user;
        }
    }
}
