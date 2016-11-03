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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class FrmProducto : Window
    {
        public Producto entProducto { get; set; }

        public FrmProducto()
        {
            InitializeComponent();
            llenarProductos(this.txtNombreProducto.Text);
        }

        private void llenarProductos(string NombreProducto)
        {
            ProductoBC productoBC = new ProductoBC();
            try
            {
                dgProductos.ItemsSource = productoBC.ListarProductos(NombreProducto);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error en la aplicación");
            }
        }

        public void InicializarModoLectura()
        {
            this.dgProductos.Columns[5].Visibility = Visibility.Visible;
            this.dgProductos.Columns[6].Visibility = Visibility.Hidden;
            this.dgProductos.Columns[7].Visibility = Visibility.Hidden;
        }

        private void btnNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            FrmMantProducto frmMantProducto = new FrmMantProducto();
            frmMantProducto.agregarNuevoProducto();
            bool? result = frmMantProducto.ShowDialog();
            if (result ?? false)
                llenarProductos(this.txtNombreProducto.Text);
        }

        private void dgCellBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Button CellBtnEditar = sender as Button;
            Producto producto = CellBtnEditar.DataContext as Producto;
            FrmMantProducto frmMantProducto = new FrmMantProducto();
            frmMantProducto.editarProducto(producto);
            bool? result = frmMantProducto.ShowDialog();
            if (result ?? false)
                llenarProductos(this.txtNombreProducto.Text);
        }

        private void dgCellBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = (sender as Button).DataContext as Producto;
            MessageBoxResult resultado = MessageBox.Show(Variables.MsgConfirmacion, Variables.TituloMensaje,
                MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                try
                {
                    ProductoBC productoBC = new ProductoBC();
                    productoBC.EliminarProducto(producto.IdProducto);
                    MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje, MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    llenarProductos(this.txtNombreProducto.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            llenarProductos(this.txtNombreProducto.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgCellBtnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            Button dgCellBtnCargarDatos = sender as Button;
            entProducto = dgCellBtnCargarDatos.DataContext as Producto;
            this.DialogResult = true;
        }
    }
}
