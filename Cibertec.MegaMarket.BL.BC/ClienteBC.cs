using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class ClienteBC
    {
        public List<Cliente> ListarClientes(string NombreCliente)
        {
            return new ClienteDALC().ListarClientes(NombreCliente).ToList();
        }

        public void InsertarCliente(Cliente cliente)
        {
            new ClienteDALC().InsertarCliente(cliente);
        }

        public void ActualizarCliente(Cliente cliente)
        {
            new ClienteDALC().ActualizarCliente(cliente);
        }

        public void EliminarCliente(int CodCliente)
        {
            new ClienteDALC().EliminarCliente(CodCliente);
        }
    }
}
