using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.DL.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.MegaMarket.BL.BC
{
    public class PedidoBC
    {
        public List<Pedido> ListarPedidos(Pedido pedido)
        {
            return new PedidoDALC().ListarPedidos(pedido).ToList();
        }
        public void InsertarPedido(Pedido pedido, List<DetallePedido> detPedido)
        {
            new PedidoDALC().InsertarPedido(pedido, detPedido);
        }

        public void EliminarPedido(int CodPedido)
        {
            new PedidoDALC().EliminarPedido(CodPedido);
        }

        public List<DetallePedido> ListarDetallePedidoPorPedido(int CodPedido)
        {
            return new PedidoDALC().ListarDetallePedidoPorPedido(CodPedido).ToList();
        }
    }
}
