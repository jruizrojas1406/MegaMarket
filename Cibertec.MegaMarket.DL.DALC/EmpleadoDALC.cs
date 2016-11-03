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
    public class EmpleadoDALC
    {
        public IQueryable<Empleado> ListarEmpleados(string NombreEmpleado)
        {
            var bd = new MegaMarketEntities();
            return bd.Empleadoes
                .Include(x=>x.Cargo)
                .Where(s => s.Nombres.Contains(NombreEmpleado));
        }

        public void InsertarEmpleado(Empleado empleado)
        {
            using (var db = new MegaMarketEntities())
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges(); ;
            }
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            using (var bd = new MegaMarketEntities())
            {
                var updateEmpleado = bd.Empleadoes.SingleOrDefault(x => x.IdEmpleado == empleado.IdEmpleado);
                // Actualizamos el registro
                updateEmpleado.Nombres = empleado.Nombres.Trim();
                updateEmpleado.Apellidos = empleado.Apellidos.Trim();
                updateEmpleado.IdCargo = empleado.IdCargo;
                bd.SaveChanges();
            }
        }

        public void EliminarEmpleado(int CodEmpleado)
        {
            using (var db = new MegaMarketEntities())
            {
                var empleado = db.Empleadoes.SingleOrDefault(x => x.IdEmpleado == CodEmpleado);
                db.Empleadoes.Remove(empleado);
                db.SaveChanges();
            }
        }
    }
}
