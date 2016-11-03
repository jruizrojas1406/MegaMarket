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
    public class PedidoDALC
    {
        public IQueryable<Pedido> ListarPedidos(Pedido pedido)
        {
            var db = new MegaMarketEntities();
            return db.Pedidoes
                .Include(a => a.Cliente)
                .Include(b => b.Empleado)
                .Include(c => c.FormaPago)
                .Include(d => d.TipoComprobante)
                .Include(e => e.Moneda);
        }

        public void InsertarPedido(Pedido pedido, List<DetallePedido> detPedido)
        {
            using (var db = new MegaMarketEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Pedidoes.Add(pedido);
                        int CodPedido = pedido.IdPedido;

                        foreach (var item in detPedido)
                        {
                            item.IdPedido = CodPedido;
                            db.DetallePedidoes.Add(item);
                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void EliminarPedido(int CodPedido)
        {
            using (var db = new MegaMarketEntities())
            {
                var pedido = db.Pedidoes.SingleOrDefault(x => x.IdPedido == CodPedido);
                db.Pedidoes.Remove(pedido);
                db.SaveChanges();
            }
        }

        public IQueryable<DetallePedido> ListarDetallePedidoPorPedido(int CodPedido)
        {
            var db = new MegaMarketEntities();
            return db.DetallePedidoes
                .Include(x => x.Producto)
                .Where(s => s.IdPedido == CodPedido);
        }
    }
}
