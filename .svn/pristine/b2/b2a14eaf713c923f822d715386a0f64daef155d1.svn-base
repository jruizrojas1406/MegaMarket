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
    /// Lógica de interacción para MantCategoria.xaml
    /// </summary>
    public partial class FrmMantCategoria : Window
    {
        public string Operacion { get; set; }

        public FrmMantCategoria()
        {
            InitializeComponent();
        }

        public void agregarNuevoCategoria()
        {
            this.Operacion = "INS";
            limpiarFormulario();
        }

        public void editarCategoria(Categoria categoria)
        {
            this.Operacion = "UPD";
            limpiarFormulario();
            this.txtCodigo.Text = categoria.IdCategoria.ToString();
            this.txtNombre.Text = categoria.Nombre;
            this.txtDescripcion.Text = categoria.Descripcion;
        }

        private void limpiarFormulario()
        {
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtDescripcion.Clear();
            //this.cboCategoria.SelectedIndex
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            CategoriaBC categoriaBC = new CategoriaBC();
            Categoria categoria = new Categoria();

            if (!String.IsNullOrEmpty(this.txtCodigo.Text))
                categoria.IdCategoria = Convert.ToInt32(this.txtCodigo.Text);
            categoria.Nombre = this.txtNombre.Text;
            categoria.Descripcion = this.txtDescripcion.Text;

            try
            {
                if (Operacion.Equals("UPD"))
                    categoriaBC.ActualizarCategoria(categoria);
                else
                    categoriaBC.InsertarCategoria(categoria);
                MessageBox.Show(Variables.MsgOk, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Information);

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Variables.MsgError, Variables.TituloMensaje,
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
