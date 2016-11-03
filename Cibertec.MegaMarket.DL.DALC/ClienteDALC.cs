using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.DL.DALC
{
   public class ClienteDALC
    {
        public IQueryable<Cliente> ListarClientes(string NombreCliente)
        {
            var bd = new MegaMarketEntities();
            return bd.Clientes
                .Where(s => s.Nombres.Contains(NombreCliente));
        }

        public void InsertarCliente(Cliente cliente)
        {
            using (var db = new MegaMarketEntities())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges(); ;
            }
        }

        public void ActualizarCliente(Cliente cliente)
        {
            using (var bd = new MegaMarketEntities())
            {
                var updateCliente = bd.Clientes.SingleOrDefault(x => x.IdCliente == cliente.IdCliente);
                // Actualizamos el registro
                updateCliente.Nombres = cliente.Nombres.Trim();
                updateCliente.Apellidos = cliente.Apellidos.Trim();
                updateCliente.Telfijo = cliente.Telfijo.Trim();
                updateCliente.TelMovil = cliente.TelMovil.Trim();
                updateCliente.Direccion = cliente.Direccion.Trim();
                updateCliente.DocIdentidad = cliente.DocIdentidad.Trim();
                updateCliente.Email = cliente.Email.Trim();
                updateCliente.IdPais = cliente.IdPais;
                updateCliente.IdCiudad = cliente.IdCiudad;
                updateCliente.IdDistrito = cliente.IdDistrito;            
                bd.SaveChanges();
            }
        }

        public void EliminarCliente(int CodCliente)
        {
            using (var db = new MegaMarketEntities())
            {
                var cliente = db.Clientes.SingleOrDefault(x => x.IdCliente == CodCliente);
                db.Clientes.Remove(cliente);
                db.SaveChanges();
            }
        }
    }
}
