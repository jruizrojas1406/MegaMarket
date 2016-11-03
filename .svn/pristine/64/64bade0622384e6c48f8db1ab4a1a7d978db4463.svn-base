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
    /// Lógica de interacción para Categoria.xaml
    /// </summary>
    public partial class FrmCategoria : Window
    {
        public Categoria entCategoria { get; set; }

        public FrmCategoria()
        {
            InitializeComponent();
            llenarCategorias(this.txtNombreCategoria.Text);
        }

        private void llenarCategorias(string NombreCategoria)
        {
            CategoriaBC categoriaBC = new CategoriaBC();
            try
            {
                dgCategorias.ItemsSource = categoriaBC.ListarCategorias(NombreCategoria);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error en la aplicación");
            }
        }

        public void InicializarModoLectura()
        {
            this.dgCategorias.Columns[5].Visibility = Visibility.Visible;
            this.dgCategorias.Columns[6].Visibility = Visibility.Hidden;
            this.dgCategorias.Columns[7].Visibility = Visibility.Hidden;
        }

        private void btnNuevoCategoria_Click(object sender, RoutedEventArgs e)
        {
            FrmMantCategoria frmMantCategoria = new FrmMantCategoria();
            frmMantCategoria.agregarNuevoCategoria();
            bool? result = frmMantCategoria.ShowDialog();
            if (result ?? false)
                llenarCategorias(this.txtNombreCategoria.Text);
        }

        private void dgCellBtnEditar_Click(object sender, RoutedEventArgs e)
        {
            Button CellBtnEditar = sender as Button;
            Categoria categoria = CellBtnEditar.DataContext as Categoria;
            FrmMantCategoria frmMantCategoria = new FrmMantCategoria();
            frmMantCategoria.editarCategoria(categoria);
            bool? result = frmMantCategoria.ShowDialog();
            if (result ?? false)
                llenarCategorias(this.txtNombreCategoria.Text);
        }

        private void dgCellBtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Categoria categoria = (sender as Button).DataContext as Categoria;
            MessageBoxResult resultado = MessageBox.Show(Variables.MsgConfirmacion, Variables.TituloMensaje,
                MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (resultado == MessageBoxResult.Yes)
            {
                try
                {
                    CategoriaBC categoriaBC = new CategoriaBC();
                    categoriaBC.EliminarCategoria(categoria.IdCategoria);
                    MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje, MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    llenarCategorias(this.txtNombreCategoria.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBuscarCategoria_Click(object sender, RoutedEventArgs e)
        {
            llenarCategorias(this.txtNombreCategoria.Text);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgCellBtnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            Button dgCellBtnCargarDatos = sender as Button;
            entCategoria = dgCellBtnCargarDatos.DataContext as Categoria;
            this.DialogResult = true;
        }

    }
}
