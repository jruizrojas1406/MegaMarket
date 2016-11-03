using Cibertec.MegaMarket.BL.BC;
using Cibertec.MegaMarket.BL.BE;
using Cibertec.MegaMarket.UI.App.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cibertec.MegaMarket.UI.App.Form
{
    /// <summary>
    /// Lógica de interacción para FrmConsultarVentas.xaml
    /// </summary>
    public partial class FrmConsultarVentas : Window
    {
        public FrmConsultarVentas()
        {
            InitializeComponent();
            llenarGrillaPedido(new Pedido());
        }

        private void llenarGrillaPedido(Pedido pedido)
        {
            try
            {
                dgPedido.ItemsSource = new PedidoBC().ListarPedidos(pedido);
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgErrorAplicacion, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgDetallePedido_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido = dgDetallePedido.DataContext as Pedido;
            try
            {
                dgPedido.ItemsSource = new PedidoBC().ListarDetallePedidoPorPedido(pedido.IdPedido);
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgErrorAplicacion, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
