using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class EmpleadoBC
    {
        public List<Empleado> ListarEmpleados(string NombreEmpleado)
        {
            return new EmpleadoDALC().ListarEmpleados(NombreEmpleado).ToList();
        }

        public void InsertarEmpleado(Empleado empleado)
        {
            new EmpleadoDALC().InsertarEmpleado(empleado);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            new EmpleadoDALC().ActualizarEmpleado(empleado);
        }

        public void EliminarEmpleado(int CodEmpleado)
        {
            new EmpleadoDALC().EliminarEmpleado(CodEmpleado);
        }
    }
}
