using Cibertec.MegaMarket.BL.BC;
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

namespace Cibertec.MegaMarket.UI.Desktop.Form
{
    /// <summary>
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        public Producto()
        {
            InitializeComponent();
            llenarProductos(txtNombreProducto.Text);
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

        private void btnNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            MantProducto mantProducto = new MantProducto();
           //mantProducto.agregarNuevoProducto();
            bool? result = mantProducto.ShowDialog();
            if (result ?? false)
                llenarProductos(txtNombreProducto.Text);
        }
    }
}
