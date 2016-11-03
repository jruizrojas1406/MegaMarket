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
    /// Lógica de interacción para FrmCliente.xaml
    /// </summary>
    public partial class FrmCliente : Window
    {
        #region Variables
        public Cliente entCliente { get; set; }
        #endregion

        #region Métodos
        public FrmCliente()
        {
            InitializeComponent();
            llenarClientes(this.txtNombreCliente.Text);
        }

        private void llenarClientes(string NombreCliente)
        {
            ClienteBC clienteBC = new ClienteBC();
            try
            {
                dgClientes.ItemsSource = clienteBC.ListarClientes(NombreCliente);
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgErrorAplicacion, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void InicializarModoLectura()
        {
            dgClientes.Columns[5].Visibility = Visibility.Visible;
            dgClientes.Columns[6].Visibility = Visibility.Hidden;
            dgClientes.Columns[7].Visibility = Visibility.Hidden;
        }
        #endregion

        #region Eventos
        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            FrmMantCliente frmMantCliente = new FrmMantCliente();
            frmMantCliente.agregarNuevoCliente();
            bool? result = frmMantCliente.ShowDialog();
            if (result ?? false)
                llenarClientes(this.txtNombreCliente.Text);
        }

        private void dgCellBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Button CellBtnEditar = sender as Button;
            Cliente cliente = CellBtnEditar.DataContext as Cliente;
            FrmMantCliente frmMantCliente = new FrmMantCliente();
            frmMantCliente.editarCliente(cliente);
            bool? result = frmMantCliente.ShowDialog();
            if (result ?? false)
                llenarClientes(this.txtNombreCliente.Text);
        }

        private void dgCellBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = (sender as Button).DataContext as Cliente;
            MessageBoxResult resultado = MessageBox.Show(Variables.MsgConfirmacion, Variables.TituloMensaje,
                MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                try
                {
                    ClienteBC clienteBC = new ClienteBC();
                    clienteBC.EliminarCliente(cliente.IdCliente);
                    MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje, MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    llenarClientes(this.txtNombreCliente.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            llenarClientes(this.txtNombreCliente.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgCellBtnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            Button dgCellBtnCargarDatos = sender as Button;
            entCliente = dgCellBtnCargarDatos.DataContext as Cliente;
            this.DialogResult = true;
        }
        #endregion;
    }
}
